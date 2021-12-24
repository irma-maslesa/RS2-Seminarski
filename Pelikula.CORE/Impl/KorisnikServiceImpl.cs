using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class KorisnikServiceImpl :
        CrudServiceImpl<KorisnikResponse, Korisnik, KorisnikUpsertRequest, KorisnikUpsertRequest>,
        IKorisnikService
    {
        protected new IKorisnikValidator Validator { get; set; }
        protected ITipKorisnikaValidator TipKorisnikaValidator { get; set; }
        protected IProjekcijaValidator ProjekcijaValidator { get; set; }

        public KorisnikServiceImpl(AppDbContext context, IMapper mapper, IKorisnikValidator validator, ITipKorisnikaValidator tipKorisnikaValidator, IProjekcijaValidator projekcijaValidator) : base(context, mapper, validator) {
            Validator = validator;
            TipKorisnikaValidator = tipKorisnikaValidator;
            ProjekcijaValidator = projekcijaValidator;
        }

        public override PagedPayloadResponse<KorisnikResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Korisnik> KorisnikList = Context.Set<Korisnik>().Include(e => e.TipKorisnika).ToList();

            KorisnikList = filter != null && filter.Any() ? FilterUtility.Filter<Korisnik>.FilteredData(filter, KorisnikList) : KorisnikList;
            KorisnikList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Korisnik>.SortData(sorting, KorisnikList) : KorisnikList;

            List<KorisnikResponse> responseList = Mapper.Map<List<KorisnikResponse>>(KorisnikList);

            PaginationUtility.PagedData<KorisnikResponse> pagedResponse = PaginationUtility.Paginaion<KorisnikResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<KorisnikResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<KorisnikResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Korisnik entity = Context.Set<Korisnik>().Include(e => e.TipKorisnika).Where(e => e.Id == id).SingleOrDefault();

            KorisnikResponse response = Mapper.Map<KorisnikResponse>(entity);

            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<KorisnikResponse> Insert(KorisnikUpsertRequest request) {
            Validator.ValidateEmail(request.Email);
            Validator.ValidateKorisnickoIme(request.KorisnickoIme);
            TipKorisnikaValidator.ValidateEntityExists(request.TipKorisnikaId);

            Korisnik entity = Mapper.Map<KorisnikUpsertRequest, Korisnik>(request);
            entity = Context.Set<Korisnik>().Add(entity).Entity;

            Context.SaveChanges();

            KorisnikResponse response = Mapper.Map<Korisnik, KorisnikResponse>(entity);

            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<KorisnikResponse> Update(int id, KorisnikUpsertRequest request) {
            Validator.ValidateEntityExists(id);
            Validator.ValidateEmail(request.Email, id);
            Validator.ValidateKorisnickoIme(request.KorisnickoIme, id);
            TipKorisnikaValidator.ValidateEntityExists(request.TipKorisnikaId);

            Korisnik entity = Context.Set<Korisnik>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Korisnik>().Update(entity);
            Context.SaveChanges();

            KorisnikResponse response = Mapper.Map<Korisnik, KorisnikResponse>(entity);

            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);

        }

        public PayloadResponse<KorisnikResponse> Autentifikacija(string korisnickoIme, string lozinka) {
            var korisnik = Context.Korisnik
                .Include(x => x.TipKorisnika)
                .FirstOrDefault(x => x.KorisnickoIme == korisnickoIme);

            if (korisnik != null) {
                var newHash = PasswordHelper.GenerateHash(korisnik.LozinkaSalt, lozinka);
                if (newHash == korisnik.LozinkaHash) {
                    return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, Mapper.Map<Korisnik, KorisnikResponse>(korisnik));
                }
            }

            throw new UserException("Korisničko ime ili lozinka nisu ispravni", HttpStatusCode.BadRequest);
        }

        public PayloadResponse<KorisnikResponse> Registracija(KorisnikRegistracijaRequest request) {
            Validator.ValidateEmail(request.Email);
            Validator.ValidateKorisnickoIme(request.KorisnickoIme);

            var tipKorisnika = Context.TipKorisnika
                .FirstOrDefault(e => e.Naziv.ToLower() == KorisnikTip.Klijent.ToString().ToLower());

            var entity = Mapper.Map<KorisnikRegistracijaRequest, Korisnik>(request);
            entity.TipKorisnika = tipKorisnika;

            Context.Add(entity);
            Context.SaveChanges();

            var response = Mapper.Map<Korisnik, KorisnikResponse>(entity);
            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);
        }

        public ListPayloadResponse<LoV> GetKlijentiForTermin(int projekcijaTerminId, bool bezRezervacije) {
            ProjekcijaValidator.ValidateTerminExists(projekcijaTerminId);
            IEnumerable<Korisnik> entityList;

            if (bezRezervacije) {
                var korisniciSaRezervacijomIds = Context.Rezervacija
                    .Where(e => e.ProjekcijaTerminId == projekcijaTerminId)
                    .Select(e => e.KorisnikId)
                    .ToList();

                entityList = Context.Korisnik.Include(e => e.TipKorisnika)
                     .Where(e => !korisniciSaRezervacijomIds.Contains(e.Id) && e.TipKorisnika.Naziv == KorisnikTip.Klijent.ToString())
                     .ToList();
            }
            else
                entityList = Context.Korisnik.Include(e => e.TipKorisnika)
                     .Where(e => e.TipKorisnika.Naziv == KorisnikTip.Klijent.ToString())
                     .ToList();

            List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

            return new ListPayloadResponse<LoV>(HttpStatusCode.OK, responseList);
        }


    }
}
