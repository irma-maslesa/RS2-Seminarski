using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Rezervacija;
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
    public class RezervacijaServiceImpl :
        CrudServiceImpl<RezervacijaResponse, Rezervacija, RezervacijaUpsertRequest, RezervacijaUpsertRequest>,
        IRezervacijaService
    {
        protected new IRezervacijaValidator Validator { get; set; }
        protected IProjekcijaValidator ProjekcijaValidator { get; set; }
        protected IKorisnikValidator KorisnikValidator { get; set; }
        protected ISalaValidator SalaValidator { get; set; }

        public RezervacijaServiceImpl(AppDbContext context, IMapper mapper, IRezervacijaValidator validator, IProjekcijaValidator projekcijaValidator, IKorisnikValidator korisnikValidator, ISalaValidator salaValidator) : base(context, mapper, validator) {
            Validator = validator;
            ProjekcijaValidator = projekcijaValidator;
            KorisnikValidator = korisnikValidator;
            SalaValidator = salaValidator;
        }

        public override PagedPayloadResponse<RezervacijaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Rezervacija> entityList = Context.Set<Rezervacija>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Film)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.SjedisteRezervacija).ThenInclude(e => e.Sjediste)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Rezervacija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Rezervacija>.SortData(sorting, entityList) : entityList;

            List<RezervacijaResponse> responseList = Mapper.Map<List<RezervacijaResponse>>(entityList);

            PaginationUtility.PagedData<RezervacijaResponse> pagedResponse = PaginationUtility.Paginaion<RezervacijaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<RezervacijaResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Rezervacija entity = Context.Set<Rezervacija>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Film)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.SjedisteRezervacija).ThenInclude(e => e.Sjediste)
                .FirstOrDefault(e => e.Id == id);

            RezervacijaResponse response = Mapper.Map<RezervacijaResponse>(entity);

            return new PayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, response);
        }

        public override PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Rezervacija> entityList = Context.Set<Rezervacija>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Film)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Sala)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Rezervacija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Rezervacija>.SortData(sorting, entityList) : entityList;

            List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

            PaginationUtility.PagedData<LoV> pagedResponse = PaginationUtility.Paginaion<LoV>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<LoV>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<RezervacijaResponse> Insert(RezervacijaUpsertRequest request) {
            ProjekcijaValidator.ValidateTerminExists(request.ProjekcijaTerminId);
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            Validator.ValidateKorisnikTermin(null, request.KorisnikId, request.ProjekcijaTerminId);
            SalaValidator.ValidateSjedistaExist(request.SjedistaIds);

            var projekcijaTermin = Context.ProjekcijaTermin.FirstOrDefault(e => e.Id == request.ProjekcijaTerminId);
            var projekcija = Context.Projekcija.FirstOrDefault(e => e.Id == projekcijaTermin.ProjekcijaId);

            Rezervacija entity = Mapper.Map<RezervacijaUpsertRequest, Rezervacija>(request);
            entity.DatumProjekcije = projekcijaTermin.Termin;
            entity.Cijena = entity.BrojSjedista * projekcija.Cijena;

            entity = Context.Set<Rezervacija>().Add(entity).Entity;

            Context.SaveChanges();

            if (request.SjedistaIds != null) {
                foreach (var id in request.SjedistaIds) {
                    SjedisteRezervacija sjedisteRezervacijaEntity = new SjedisteRezervacija {
                        SjedisteId = id,
                        RezervacijaId = entity.Id
                    };

                    Context.SjedisteRezervacija.Add(sjedisteRezervacijaEntity);
                }
            }

            Context.SaveChanges();

            RezervacijaResponse response = Mapper.Map<Rezervacija, RezervacijaResponse>(entity);
            return new PayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<RezervacijaResponse> Update(int id, RezervacijaUpsertRequest request) {
            Validator.ValidateEntityExists(id);
            ProjekcijaValidator.ValidateTerminExists(request.ProjekcijaTerminId);
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            Validator.ValidateKorisnikTermin(id, request.KorisnikId, request.ProjekcijaTerminId);
            SalaValidator.ValidateSjedistaExist(request.SjedistaIds);

            var projekcijaTermin = Context.ProjekcijaTermin.FirstOrDefault(e => e.Id == request.ProjekcijaTerminId);
            var projekcija = Context.Projekcija.FirstOrDefault(e => e.Id == projekcijaTermin.ProjekcijaId);


            Rezervacija entity = Context.Set<Rezervacija>().Include(e => e.SjedisteRezervacija).FirstOrDefault(e => e.Id == id);
            var sjedisteRezervacijaForDelete = entity.SjedisteRezervacija.Where(e => !request.SjedistaIds.Contains(e.SjedisteId)).ToList();
            Context.SjedisteRezervacija.RemoveRange(sjedisteRezervacijaForDelete);

            entity.DatumProjekcije = projekcijaTermin.Termin;
            entity.Cijena = entity.BrojSjedista * projekcija.Cijena;

            entity = Mapper.Map(request, entity);

            Context.Set<Rezervacija>().Update(entity);
            Context.SaveChanges();

            if (request.SjedistaIds != null) {
                foreach (var sjedisteId in request.SjedistaIds) {
                    SjedisteRezervacija sjedisteRezervacijaEntity = Context.SjedisteRezervacija.FirstOrDefault(e => e.RezervacijaId == entity.Id && e.SjedisteId == sjedisteId);
                    if (sjedisteRezervacijaEntity == null) {
                        sjedisteRezervacijaEntity = new SjedisteRezervacija {
                            SjedisteId = sjedisteId,
                            RezervacijaId = entity.Id
                        };

                        Context.SjedisteRezervacija.Add(sjedisteRezervacijaEntity);
                    }
                }
            }

            Context.SaveChanges();

            RezervacijaResponse response = Mapper.Map<Rezervacija, RezervacijaResponse>(entity);

            return new PayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, response);
        }

        public PayloadResponse<RezervacijaResponse> GetByProjekcijaKorisnik(int projekcijaId, int korisnikId) {
            ProjekcijaValidator.ValidateEntityExists(projekcijaId);
            KorisnikValidator.ValidateEntityExists(korisnikId);

            Rezervacija entity = Context.Set<Rezervacija>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Film)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Sala)
                .FirstOrDefault(e => e.KorisnikId == korisnikId && e.ProjekcijaTermin.ProjekcijaId == projekcijaId
                    && e.DatumOtkazano == null && e.DatumProdano == null);

            RezervacijaResponse response = Mapper.Map<RezervacijaResponse>(entity);

            return new PayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, response);
        }

        public PayloadResponse<RezervacijaResponse> Otkazi(int id) {
            Validator.ValidateEntityExists(id);
            Validator.ValidateEntityOtkazano(id);
            Validator.ValidateEntityProdano(id);

            Rezervacija entity = Context.Set<Rezervacija>().Include(e => e.SjedisteRezervacija).FirstOrDefault(e => e.Id == id);

            entity.DatumOtkazano = DateTime.Now;
            Context.Set<Rezervacija>().Update(entity);
            Context.SaveChanges();

            RezervacijaResponse response = Mapper.Map<Rezervacija, RezervacijaResponse>(entity);

            return new PayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, response);
        }

        public PagedPayloadResponse<RezervacijaSimpleResponse> GetSimple(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting) {
            IEnumerable<Rezervacija> entityList = Context.Set<Rezervacija>()
               .Include(e => e.Korisnik)
               .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Film)
               .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Sala)
               .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Rezervacija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Rezervacija>.SortData(sorting, entityList) : entityList;

            List<RezervacijaSimpleResponse> responseList = Mapper.Map<List<RezervacijaSimpleResponse>>(entityList);

            PaginationUtility.PagedData<RezervacijaSimpleResponse> pagedResponse = PaginationUtility.Paginaion<RezervacijaSimpleResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<RezervacijaSimpleResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public PagedPayloadResponse<RezervacijaResponse> GetNotProdaja(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting) {
            IEnumerable<Rezervacija> entityList = Context.Set<Rezervacija>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Film)
                .Include(e => e.ProjekcijaTermin).ThenInclude(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.SjedisteRezervacija).ThenInclude(e => e.Sjediste)
                .Where(e => e.Datum != e.DatumProdano)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Rezervacija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Rezervacija>.SortData(sorting, entityList) : entityList;

            List<RezervacijaResponse> responseList = Mapper.Map<List<RezervacijaResponse>>(entityList);

            PaginationUtility.PagedData<RezervacijaResponse> pagedResponse = PaginationUtility.Paginaion<RezervacijaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<RezervacijaResponse>(HttpStatusCode.OK, pagedResponse);
        }
    }

}
