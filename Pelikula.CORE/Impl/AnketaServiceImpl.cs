using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Helper;
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
    public class AnketaServiceImpl :
        CrudServiceImpl<AnketaResponse, Anketa, AnketaInsertRequest, AnketaUpdateRequest>,
        IAnketaService
    {
        protected IKorisnikValidator KorisnikValidator { get; set; }
        protected new IAnketaValidator Validator { get; set; }

        public AnketaServiceImpl(AppDbContext context, IMapper mapper, IAnketaValidator validator, IKorisnikValidator korisnikValidator) : base(context, mapper, validator) {
            KorisnikValidator = korisnikValidator;
            Validator = validator;
        }

        public override PagedPayloadResponse<AnketaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Anketa> entityList = Context.Set<Anketa>().Include(e => e.Korisnik).Include(e => e.AnketaOdgovor).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Anketa>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Anketa>.SortData(sorting, entityList) : entityList;

            List<AnketaResponse> responseList = Mapper.Map<List<AnketaResponse>>(entityList);

            PaginationUtility.PagedData<AnketaResponse> pagedResponse = PaginationUtility.Paginaion<AnketaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<AnketaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<AnketaResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Anketa entity = Context.Set<Anketa>().Include(e => e.Korisnik).Include(e => e.AnketaOdgovor).FirstOrDefault(e => e.Id == id);

            AnketaResponse response = Mapper.Map<AnketaResponse>(entity);

            return new PayloadResponse<AnketaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<AnketaResponse> Insert(AnketaInsertRequest request) {
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            Validator.ValidateOdgovori(request.Odgovori);

            Anketa entity = Mapper.Map<AnketaInsertRequest, Anketa>(request);
            entity = Context.Set<Anketa>().Add(entity).Entity;
            Context.SaveChanges();

            if (request.Odgovori != null) {
                foreach (var odgovor in request.Odgovori) {
                    odgovor.AnketaId = entity.Id;
                    Context.AnketaOdgovor.Add(Mapper.Map<AnketaOdgovorInsertRequest, AnketaOdgovor>(odgovor));
                }

            }

            Context.SaveChanges();

            AnketaResponse response = Mapper.Map<Anketa, AnketaResponse>(entity);

            return new PayloadResponse<AnketaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<AnketaResponse> Update(int id, AnketaUpdateRequest request) {
            Validator.ValidateEntityExists(id);
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            Validator.ValidateOdgovori(request.Odgovori);

            Anketa entity = Context.Set<Anketa>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Anketa>().Update(entity);
            Context.SaveChanges();

            if (request.Odgovori != null) {
                foreach (var odgovor in request.Odgovori) {
                    AnketaOdgovor odgovorEntity = Context.AnketaOdgovor.Find(odgovor.Id);

                    if (odgovorEntity != null) {
                        odgovorEntity = Mapper.Map(odgovor, odgovorEntity);
                        Context.AnketaOdgovor.Update(odgovorEntity);
                    }
                    else {
                        odgovor.AnketaId = entity.Id;
                        Context.AnketaOdgovor.Add(Mapper.Map<AnketaOdgovorUpdateRequest, AnketaOdgovor>(odgovor));

                    }
                }
            }

            Context.SaveChanges();

            AnketaResponse response = Mapper.Map<Anketa, AnketaResponse>(entity);

            return new PayloadResponse<AnketaResponse>(HttpStatusCode.OK, response);
        }

        public PayloadResponse<AnketaExtendedResponse> InsertKorisnikOdgovor(AnketaOdgovorKorisnikInsertRequest request) {
            Validator.ValidateOdgovorExists(request.AnketaOdgovorId);
            Validator.ValidateKorisnikOdgovorDoesNotExists(request.KorisnikId, request.AnketaOdgovorId);

            var anketaOdgovor = Context.AnketaOdgovor.FirstOrDefault(e => e.Id == request.AnketaOdgovorId);
            anketaOdgovor.UkupnoIzabrano++;

            var anketa = Context.Anketa
                .Include(e => e.Korisnik)
                .Include(e => e.AnketaOdgovor)
                .FirstOrDefault(e => e.Id == anketaOdgovor.AnketaId);

            var anketaOdgovorKorisnikEntity = Mapper.Map<AnketaOdgovorKorisnikInsertRequest, AnketaOdgovorKorisnik>(request);
            anketaOdgovorKorisnikEntity.Datum = DateTime.Now;
            Context.AnketaOdgovorKorisnik.Add(anketaOdgovorKorisnikEntity);
            Context.SaveChanges();

            var anketaResponse = Mapper.Map<Anketa, AnketaResponse>(anketa);
            var anketaExtendedReponse = GetAnketaExtendedResponse(anketaResponse, request.KorisnikId);

            return new PayloadResponse<AnketaExtendedResponse>(HttpStatusCode.OK, anketaExtendedReponse);
        }

        private AnketaExtendedResponse GetAnketaExtendedResponse(AnketaResponse anketa, int korisnikId) {
            var anketaEx = new AnketaExtendedResponse(anketa);

            var korisnikOdgovor = Context.AnketaOdgovorKorisnik
                .Include(x => x.AnketaOdgovor)
                .Where(x => x.AnketaOdgovor.AnketaId == anketaEx.Id && x.KorisnikId == korisnikId)
                .FirstOrDefault();

            if (korisnikOdgovor != null) {
                anketaEx.KorisnikAnketaOdgovor = Mapper.Map<AnketaOdgovor, AnketaOdgovorResponse>(korisnikOdgovor.AnketaOdgovor);
            }

            return anketaEx;
        }

        public PayloadResponse<AnketaResponse> Close(int id) {
            Validator.ValidateEntityExists(id);
            Validator.ValidateAnketaIsNotClosed(id);

            Anketa entity = Context.Set<Anketa>().Include(e => e.Korisnik).Include(e => e.AnketaOdgovor).FirstOrDefault(e => e.Id == id);
            entity.ZakljucenoDatum = DateTime.Now;

            Context.Set<Anketa>().Update(entity);
            Context.SaveChanges();

            AnketaResponse response = Mapper.Map<Anketa, AnketaResponse>(entity);

            return new PayloadResponse<AnketaResponse>(HttpStatusCode.OK, response);
        }

        public PagedPayloadResponse<AnketaResponse> GetActive(int? korisnikId, PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting) {
            IEnumerable<Anketa> entityList;

            if (korisnikId.HasValue) {
                List<int> anketaIds = Context.AnketaOdgovorKorisnik.
                   Where(e => e.KorisnikId == korisnikId.Value)
                   .Include(e => e.AnketaOdgovor)
                   .Select(e => e.AnketaOdgovor.AnketaId)
                   .Distinct()
                   .ToList();

                entityList = Context.Set<Anketa>()
                .Include(e => e.Korisnik)
                .Include(e => e.AnketaOdgovor)
                .Where(e => e.ZakljucenoDatum == null && !anketaIds.Contains(e.Id))
                .ToList();
            }

            else {
                entityList = Context.Set<Anketa>()
                .Include(e => e.Korisnik)
                .Include(e => e.AnketaOdgovor)
                .Where(e => e.ZakljucenoDatum == null)
                .ToList();
            }

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Anketa>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Anketa>.SortData(sorting, entityList) : entityList;

            List<AnketaResponse> responseList = Mapper.Map<List<AnketaResponse>>(entityList);

            PaginationUtility.PagedData<AnketaResponse> pagedResponse = PaginationUtility.Paginaion<AnketaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<AnketaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public PagedPayloadResponse<AnketaExtendedResponse> GetForUser(int korisnikId, PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting) {
            IEnumerable<Anketa> entityList = Context.Set<Anketa>()
                .Include(e => e.Korisnik)
                .Include(e => e.AnketaOdgovor)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Anketa>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Anketa>.SortData(sorting, entityList) : entityList;
            List<AnketaResponse> anketaList = Mapper.Map<List<AnketaResponse>>(entityList);

            List<AnketaExtendedResponse> responseList = new List<AnketaExtendedResponse>();

            foreach (var anketa in anketaList)
                responseList.Add(GetAnketaExtendedResponse(anketa, korisnikId));

            responseList = responseList.Where(e => e.KorisnikAnketaOdgovor != null || e.ZakljucenoDatum == null).ToList();

            PaginationUtility.PagedData<AnketaExtendedResponse> pagedResponse = PaginationUtility.Paginaion<AnketaExtendedResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<AnketaExtendedResponse>(HttpStatusCode.OK, pagedResponse);
        }
    }
}
