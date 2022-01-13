using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class ProjekcijaServiceImpl :
        CrudServiceImpl<ProjekcijaResponse, Projekcija, ProjekcijaUpsertRequest, ProjekcijaUpsertRequest>,
        IProjekcijaService
    {
        protected new IProjekcijaValidator Validator { get; set; }
        protected IFilmValidator FilmValidator { get; set; }
        protected ISalaValidator SalaValidator { get; set; }
        protected IKorisnikValidator KorisnikValidator { get; set; }
        protected IZanrValidator ZanrValidator { get; set; }

        public ProjekcijaServiceImpl(AppDbContext context, IMapper mapper, IProjekcijaValidator validator, IFilmValidator filmValidator, ISalaValidator salaValidator, IKorisnikValidator korisnikValidator, IZanrValidator zanrValidator) : base(context, mapper, validator) {
            SalaValidator = salaValidator;
            FilmValidator = filmValidator;
            KorisnikValidator = korisnikValidator;
            ZanrValidator = zanrValidator;
            Validator = validator;
        }

        public override PagedPayloadResponse<ProjekcijaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>().Include(e => e.Film).Include(e => e.Sala).Include(e => e.ProjekcijaTermin).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            List<ProjekcijaResponse> responseList = Mapper.Map<List<ProjekcijaResponse>>(entityList);

            PaginationUtility.PagedData<ProjekcijaResponse> pagedResponse = PaginationUtility.Paginaion<ProjekcijaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ProjekcijaResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Projekcija entity = Context.Set<Projekcija>().Include(e => e.Film).Include(e => e.Sala).Include(e => e.ProjekcijaTermin).FirstOrDefault(e => e.Id == id);

            ProjekcijaResponse response = Mapper.Map<ProjekcijaResponse>(entity);

            return new PayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, response);
        }

        public override PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>().Include(e => e.Film).Include(e => e.Sala).Include(e => e.ProjekcijaTermin).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

            PaginationUtility.PagedData<LoV> pagedResponse = PaginationUtility.Paginaion<LoV>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<LoV>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ProjekcijaResponse> Insert(ProjekcijaUpsertRequest request) {
            Validator.ValidateEntityExists(null, request);
            SalaValidator.ValidateEntityExists(request.SalaId);
            FilmValidator.ValidateEntityExists(request.FilmId);
            var trajanjeFilma = Context.Film.Where(e => e.Id == request.FilmId).Select(e => e.Trajanje).First();
            Validator.ValidateTermin(request.ProjekcijaTermin, trajanjeFilma);

            request.VrijediOd = new DateTime(request.VrijediOd.Year, request.VrijediOd.Month, request.VrijediOd.Day, 0, 0, 0, 0);
            request.VrijediDo = new DateTime(request.VrijediDo.Year, request.VrijediDo.Month, request.VrijediDo.Day, 23, 59, 59, 999);
            Projekcija entity = Mapper.Map<ProjekcijaUpsertRequest, Projekcija>(request);
            entity = Context.Set<Projekcija>().Add(entity).Entity;
            Context.SaveChanges();

            var numberOfDays = (request.VrijediDo - request.VrijediOd).TotalDays;

            if (request.ProjekcijaTermin != null) {
                foreach (var termin in request.ProjekcijaTermin) {
                    termin.ProjekcijaId = entity.Id;
                    for (int i = 0; i <= numberOfDays; i++) {
                        termin.Termin = request.VrijediOd.AddDays(i).Date.Add(termin.Termin.TimeOfDay);
                        Context.ProjekcijaTermin.Add(Mapper.Map<ProjekcijaTerminUpsertRequest, ProjekcijaTermin>(termin));
                    }
                }

            }

            Context.SaveChanges();

            ProjekcijaResponse response = Mapper.Map<Projekcija, ProjekcijaResponse>(entity);

            return new PayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ProjekcijaResponse> Update(int id, ProjekcijaUpsertRequest request) {
            Validator.ValidateEntityExists(id, request);
            Validator.ValidateEntityExists(id);
            SalaValidator.ValidateEntityExists(request.SalaId);
            FilmValidator.ValidateEntityExists(request.FilmId);
            var trajanjeFilma = Context.Film.Where(e => e.Id == request.FilmId).Select(e => e.Trajanje).First();
            Validator.ValidateTermin(request.ProjekcijaTermin, trajanjeFilma);

            Projekcija entity = Context.Set<Projekcija>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Projekcija>().Update(entity);
            Context.SaveChanges();

            var numberOfDays = (request.VrijediDo - request.VrijediOd).TotalDays;

            if (request.ProjekcijaTermin != null) {
                var projekcijaTerminEntites = Context.ProjekcijaTermin.Where(e => e.ProjekcijaId == entity.Id).ToList();
                var entitesGroupedByTime = projekcijaTerminEntites.GroupBy(e => e.Termin.TimeOfDay);
                var terminiList = entitesGroupedByTime.Select(e => e.Key).ToList();

                var existingTerminTimes = request.ProjekcijaTermin.Select(e => e.Termin.TimeOfDay);

                var terminTimesForDelete = terminiList.Where(e => !existingTerminTimes.Contains(e)).ToList();

                var projekcijaTerminEntitesForDelete = projekcijaTerminEntites.Where(e => terminTimesForDelete.Contains(e.Termin.TimeOfDay)).ToList();
                Context.RemoveRange(projekcijaTerminEntitesForDelete);

                foreach (var termin in request.ProjekcijaTermin) {
                    if (!terminiList.Contains(termin.Termin.TimeOfDay)) {
                        termin.ProjekcijaId = entity.Id;
                        for (int i = 0; i <= numberOfDays; i++) {
                            termin.Termin = request.VrijediOd.AddDays(i).Date.Add(termin.Termin.TimeOfDay);
                            Context.ProjekcijaTermin.Add(Mapper.Map<ProjekcijaTerminUpsertRequest, ProjekcijaTermin>(termin));
                        }

                    }

                }

            }

            Context.SaveChanges();

            ProjekcijaResponse response = Mapper.Map<Projekcija, ProjekcijaResponse>(entity);

            return new PayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, response);
        }

        public PagedPayloadResponse<ProjekcijaResponse> GetActive(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting) {
            var datum = DateTime.Now.Date;

            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>()
                .Include(e => e.Film)
                .Include(e => e.Sala)
                .Include(e => e.ProjekcijaTermin)
                .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo >= datum)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            List<ProjekcijaResponse> responseList = Mapper.Map<List<ProjekcijaResponse>>(entityList);

            PaginationUtility.PagedData<ProjekcijaResponse> pagedResponse = PaginationUtility.Paginaion<ProjekcijaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public ListPayloadResponse<ProjekcijaDetailedResponse> GetPreporucene(int korisnikId) {

            var datum = DateTime.Now;

            var korisnici = Context.Korisnik.Where(e => e.Id != korisnikId && e.TipKorisnika.Naziv == KorisnikTip.Klijent.ToString()).ToList();

            Dictionary<Korisnik, List<Dojam>> korisnikOcjene = new Dictionary<Korisnik, List<Dojam>>();
            foreach (var korisnik in korisnici) {
                var ocjene = Context.Dojam
                    .Where(e => e.KorisnikId == korisnik.Id)
                    .ToList();
                korisnikOcjene.Add(korisnik, ocjene);
            }

            var dojmoviPosmatraca = Context.Dojam.Where(e => e.KorisnikId == korisnikId).ToList();

            if (dojmoviPosmatraca == null || dojmoviPosmatraca.Count == 0)
                return new ListPayloadResponse<ProjekcijaDetailedResponse>(HttpStatusCode.OK, new List<ProjekcijaDetailedResponse>());

            List<Dojam> zajednickeOcjenePosmatrac = new List<Dojam>();
            List<Dojam> zajednickeOcjeneKorisnik2 = new List<Dojam>();

            var rezervisaneProjekcijeIds = Context.Rezervacija
                .Where(e => e.KorisnikId == korisnikId && e.DatumOtkazano == null)
                .Select(e => e.ProjekcijaTermin.ProjekcijaId)
                .ToList();
            var preporuceneProjekcijeIds = new List<int>();

            foreach (var item in korisnikOcjene) {
                foreach (var dojam in dojmoviPosmatraca) {
                    if (item.Value.Any(e => e.ProjekcijaId == dojam.ProjekcijaId)) {
                        zajednickeOcjenePosmatrac.Add(dojam);
                        zajednickeOcjeneKorisnik2.Add(item.Value.FirstOrDefault(e => e.ProjekcijaId == dojam.ProjekcijaId));
                    }
                }

                double slicnost = GetSlicnost(zajednickeOcjenePosmatrac, zajednickeOcjeneKorisnik2);

                if (slicnost > 0.5) {
                    var dobroOcjenjeneProjekcijeIds = korisnikOcjene
                        .Select(e => e.Value)
                        .SelectMany(e => e)
                        .Where(e => e.Ocjena > 3)
                        .Select(e => e.ProjekcijaId)
                        .Where(e => !rezervisaneProjekcijeIds.Contains(e))
                        .ToList();

                    dobroOcjenjeneProjekcijeIds.ForEach(e => {
                        if (!preporuceneProjekcijeIds.Contains(e))
                            preporuceneProjekcijeIds.Add(e);
                    });
                }

                zajednickeOcjenePosmatrac.Clear();
                zajednickeOcjeneKorisnik2.Clear();
            }

            var preporuceneProjekcije = Context.Set<Projekcija>()
                .Include(e => e.Film)
                    .ThenInclude(e => e.Zanr)
                .Include(e => e.Film)
                    .ThenInclude(e => e.Reditelj)
                .Include(e => e.Film)
                    .ThenInclude(e => e.FilmGlumac)
                        .ThenInclude(e => e.FilmskaLicnost)
                .Include(e => e.Sala)
                .Include(e => e.ProjekcijaTermin)
                .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo >= datum && preporuceneProjekcijeIds.Contains(e.Id))
                .ToList();

            List<ProjekcijaDetailedResponse> preporuceneProjekcijeResponse = Mapper.Map<List<ProjekcijaDetailedResponse>>(preporuceneProjekcije);
            return new ListPayloadResponse<ProjekcijaDetailedResponse>(HttpStatusCode.OK, preporuceneProjekcijeResponse);
        }

        private double GetSlicnost(List<Dojam> zajednickeOcjene1, List<Dojam> zajednickeOcjene2) {
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
                return 0;

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajednickeOcjene1.Count; i++) {
                brojnik += zajednickeOcjene1[i].Ocjena * zajednickeOcjene2[i].Ocjena;
                nazivnik1 += zajednickeOcjene1[i].Ocjena * zajednickeOcjene1[i].Ocjena;
                nazivnik2 += zajednickeOcjene2[i].Ocjena * zajednickeOcjene2[i].Ocjena;
            }
            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);

            double nazivnik = nazivnik1 * nazivnik2;
            if (nazivnik == 0)
                return 0;
            else
                return brojnik / nazivnik;
        }

        public PayloadResponse<string> PosjetiProjekciju(int projekcijaId, int korisnikId) {
            Validator.ValidateEntityExists(projekcijaId);
            KorisnikValidator.ValidateEntityExists(korisnikId);

            var datum = DateTime.Now;

            var projekcijaKorisnik = Context.ProjekcijaKorisnik
                .FirstOrDefault(x => x.ProjekcijaId == projekcijaId && x.KorisnikId == korisnikId);

            if (projekcijaKorisnik == null) {
                projekcijaKorisnik = new ProjekcijaKorisnik() {
                    DatumPosjete = datum,
                    KorisnikId = korisnikId,
                    ProjekcijaId = projekcijaId
                };

                Context.Add(projekcijaKorisnik);
            }


            projekcijaKorisnik.DatumPosljednjePosjete = datum;
            Context.SaveChanges();

            return new PayloadResponse<string>(HttpStatusCode.OK, "Posjeta uspješno dodana!");
        }

        public ListPayloadResponse<LoV> GetTermine(int projekcijaId) {
            Validator.ValidateEntityExists(projekcijaId);
            List<ProjekcijaTermin> entityList = Context.Set<ProjekcijaTermin>().Where(e => e.ProjekcijaId == projekcijaId).ToList();

            List<LoV> response = Mapper.Map<List<LoV>>(entityList);

            return new ListPayloadResponse<LoV>(HttpStatusCode.OK, response);
        }

        public ListPayloadResponse<LoV> GetAktivneTermine(int projekcijaId) {
            Validator.ValidateEntityExists(projekcijaId);

            List<ProjekcijaTermin> entityList = Context.Set<ProjekcijaTermin>()
                .Where(e => e.ProjekcijaId == projekcijaId && e.Termin > DateTime.Now)
                .ToList();

            List<LoV> response = Mapper.Map<List<LoV>>(entityList);

            return new ListPayloadResponse<LoV>(HttpStatusCode.OK, response);
        }

        public PagedPayloadResponse<ProjekcijaDetailedResponse> GetDetailedActive(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting, string naziv, int? zanrId) {
            var datum = DateTime.Now.Date;

            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>()
                .Include(e => e.Film)
                    .ThenInclude(e => e.Zanr)
                .Include(e => e.Film)
                    .ThenInclude(e => e.Reditelj)
                .Include(e => e.Film)
                    .ThenInclude(e => e.FilmGlumac)
                        .ThenInclude(e => e.FilmskaLicnost)
                .Include(e => e.Sala)
                .Include(e => e.ProjekcijaTermin)
                .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo >= datum)
                .ToList();

            entityList.ToList().ForEach(e => e.ProjekcijaTermin = e.ProjekcijaTermin.Where(o => o.Termin > datum).ToList());

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            if (naziv != null)
                entityList = entityList.Where(e => e.Film.Naslov.ToLower().Contains(naziv.ToLower()));
            if (zanrId != null) {
                ZanrValidator.ValidateEntityExists(zanrId.Value);
                entityList = entityList.Where(e => e.Film.ZanrId == zanrId.Value);
            }

            List<ProjekcijaDetailedResponse> responseList = Mapper.Map<List<ProjekcijaDetailedResponse>>(entityList);

            PaginationUtility.PagedData<ProjekcijaDetailedResponse> pagedResponse = PaginationUtility.Paginaion<ProjekcijaDetailedResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProjekcijaDetailedResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public PagedPayloadResponse<ProjekcijaDetailedResponse> GetDetailedComingSoon(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting, string naziv, int? zanrId) {
            var datum = DateTime.Now.Date;

            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>()
                .Include(e => e.Film)
                    .ThenInclude(e => e.Zanr)
                .Include(e => e.Film)
                    .ThenInclude(e => e.Reditelj)
                .Include(e => e.Film)
                    .ThenInclude(e => e.FilmGlumac)
                        .ThenInclude(e => e.FilmskaLicnost)
                .Include(e => e.Sala)
                .Include(e => e.ProjekcijaTermin)
                .Where(e => e.VrijediOd.Date > datum && e.VrijediOd <= datum.AddDays(10))
                .ToList();

            entityList.ToList().ForEach(e => e.ProjekcijaTermin = e.ProjekcijaTermin.Where(o => o.Termin > datum).ToList());

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            if (naziv != null)
                entityList = entityList.Where(e => e.Film.Naslov.ToLower().Contains(naziv.ToLower()));
            if (zanrId != null) {
                ZanrValidator.ValidateEntityExists(zanrId.Value);
                entityList = entityList.Where(e => e.Film.ZanrId == zanrId.Value);
            }

            List<ProjekcijaDetailedResponse> responseList = Mapper.Map<List<ProjekcijaDetailedResponse>>(entityList);

            PaginationUtility.PagedData<ProjekcijaDetailedResponse> pagedResponse = PaginationUtility.Paginaion<ProjekcijaDetailedResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProjekcijaDetailedResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public ListPayloadResponse<LoV> GetAktivneTermineZaKorisnika(int projekcijaId, int korisnikId) {
            Validator.ValidateEntityExists(projekcijaId);
            KorisnikValidator.ValidateEntityExists(korisnikId);

            List<int> rezervisaniTermini = Context.Set<Rezervacija>()
                .Include(e => e.ProjekcijaTermin.Projekcija)
                .Where(e => e.ProjekcijaTermin.ProjekcijaId == projekcijaId && e.KorisnikId == korisnikId && e.DatumOtkazano == null)
                .Select(e => e.ProjekcijaTerminId)
                .ToList();


            List<ProjekcijaTermin> entityList = Context.Set<ProjekcijaTermin>()
                .Where(e => e.ProjekcijaId == projekcijaId && e.Termin > DateTime.Now && !rezervisaniTermini.Contains(e.Id))
                .OrderBy(e => e.Termin)
                .ToList();

            List<LoV> response = Mapper.Map<List<LoV>>(entityList);

            return new ListPayloadResponse<LoV>(HttpStatusCode.OK, response);
        }
    }
}
