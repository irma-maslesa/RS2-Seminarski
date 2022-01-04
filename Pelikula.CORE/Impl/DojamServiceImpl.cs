using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Dojam;
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
    public class DojamServiceImpl :
        CrudServiceImpl<DojamResponse, Dojam, DojamUpsertRequest, DojamUpsertRequest>,
        IDojamService
    {
        protected new IDojamValidator Validator { get; set; }
        protected IKorisnikValidator KorisnikValidator { get; set; }
        protected IProjekcijaValidator ProjekcijaValidator { get; set; }

        public DojamServiceImpl(AppDbContext context, IMapper mapper, IDojamValidator validator, IKorisnikValidator korisnikValidator, IProjekcijaValidator projekcijaValidator) : base(context, mapper, validator) {
            Validator = validator;
            KorisnikValidator = korisnikValidator;
            ProjekcijaValidator = projekcijaValidator;
        }

        public override PagedPayloadResponse<DojamResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Dojam> entityList = Context.Set<Dojam>().Include(e => e.Korisnik)
                .Include(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.Projekcija).ThenInclude(e => e.Film)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Dojam>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Dojam>.SortData(sorting, entityList) : entityList;

            List<DojamResponse> responseList = Mapper.Map<List<DojamResponse>>(entityList);

            PaginationUtility.PagedData<DojamResponse> pagedResponse = PaginationUtility.Paginaion<DojamResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<DojamResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<DojamResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Dojam entity = Context.Set<Dojam>().Include(e => e.Korisnik)
                .Include(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.Projekcija).ThenInclude(e => e.Film)
                .FirstOrDefault(e => e.Id == id);

            DojamResponse response = Mapper.Map<DojamResponse>(entity);

            return new PayloadResponse<DojamResponse>(HttpStatusCode.OK, response);
        }

        public override PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Dojam> entityList = Context.Set<Dojam>()
                .Include(e => e.Korisnik)
                .Include(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.Projekcija).ThenInclude(e => e.Film)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Dojam>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Dojam>.SortData(sorting, entityList) : entityList;

            List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

            PaginationUtility.PagedData<LoV> pagedResponse = PaginationUtility.Paginaion<LoV>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<LoV>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<DojamResponse> Insert(DojamUpsertRequest request) {
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            ProjekcijaValidator.ValidateEntityExists(request.ProjekcijaId);
            Validator.ValidateComboDoesNotExist(null, request.KorisnikId, request.ProjekcijaId);

            Dojam entity = Mapper.Map<DojamUpsertRequest, Dojam>(request);
            entity.Datum = DateTime.Now;

            entity = Context.Set<Dojam>().Add(entity).Entity;

            Context.SaveChanges();

            DojamResponse response = Mapper.Map<Dojam, DojamResponse>(entity);

            return new PayloadResponse<DojamResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<DojamResponse> Update(int id, DojamUpsertRequest request) {
            Validator.ValidateEntityExists(id);
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            ProjekcijaValidator.ValidateEntityExists(request.ProjekcijaId);
            Validator.ValidateComboDoesNotExist(id, request.KorisnikId, request.ProjekcijaId);

            Dojam entity = Context.Set<Dojam>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Dojam>().Update(entity);
            Context.SaveChanges();

            DojamResponse response = Mapper.Map<Dojam, DojamResponse>(entity);

            return new PayloadResponse<DojamResponse>(HttpStatusCode.OK, response);
        }

        public PayloadResponse<DojamResponse> GetByProjekcijaKorisnik(int projekcijaId, int korisnikId) {
            KorisnikValidator.ValidateEntityExists(korisnikId);
            ProjekcijaValidator.ValidateEntityExists(projekcijaId);

            Dojam entity = Context.Set<Dojam>()
                .Include(e => e.Korisnik)
                .Include(e => e.Projekcija).ThenInclude(e => e.Sala)
                .Include(e => e.Projekcija).ThenInclude(e => e.Film)
                .FirstOrDefault(e => e.KorisnikId == korisnikId && e.ProjekcijaId == projekcijaId);

            DojamResponse response = Mapper.Map<DojamResponse>(entity);

            return new PayloadResponse<DojamResponse>(HttpStatusCode.OK, response);
        }
    }
}
