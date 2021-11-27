using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Film;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Pelikula.CORE.Filter;

namespace Pelikula.CORE.Impl
{
    public class FilmServiceImpl :
        CrudServiceImpl<FilmResponse, Film, FilmUpsertRequest, FilmUpsertRequest>,
        IFilmService
    {
        protected IZanrValidator ZanrValidator { get; set; }
        protected IFilmskaLicnostValidator FilmskaLicnostValidator { get; set; }

        public FilmServiceImpl(AppDbContext context, IMapper mapper, IFilmValidator validator, IZanrValidator zanrValidator, IFilmskaLicnostValidator filmskaLicnostValidator) : base(context, mapper, validator)
        {
            ZanrValidator = zanrValidator;
            FilmskaLicnostValidator = filmskaLicnostValidator;
        }

        public override PagedPayloadResponse<FilmResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Film> entityList = Context.Set<Film>().Include(e => e.Zanr).Include(e => e.Reditelj).Include(e => e.FilmGlumac).ThenInclude(e => e.FilmskaLicnost).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Film>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Film>.SortData(sorting, entityList) : entityList;

            List<FilmResponse> responseList = Mapper.Map<List<FilmResponse>>(entityList);

            PaginationUtility.PagedData<FilmResponse> pagedResponse = PaginationUtility.Paginaion<FilmResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<FilmResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<FilmResponse> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Film entity = Context.Set<Film>().Include(e => e.Zanr).Include(e => e.Reditelj).Include(e => e.FilmGlumac).ThenInclude(e => e.FilmskaLicnost).FirstOrDefault(e => e.Id == id);

            FilmResponse response = Mapper.Map<FilmResponse>(entity);

            return new PayloadResponse<FilmResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<FilmResponse> Insert(FilmUpsertRequest request)
        {
            if (request.ZanrId.HasValue)
                ZanrValidator.ValidateEntityExists(request.ZanrId.Value);
            if (request.RediteljId.HasValue)
                FilmskaLicnostValidator.ValidateEntityExists(request.RediteljId.Value);
            if (request.FilmGlumacIds != null)
                FilmskaLicnostValidator.ValidateEntitiesExists(request.FilmGlumacIds);

            Film entity = Mapper.Map<FilmUpsertRequest, Film>(request);

            entity = Context.Set<Film>().Add(entity).Entity;

            Context.SaveChanges();

            if (request.FilmGlumacIds != null)
            {
                foreach (var id in request.FilmGlumacIds)
                {
                    FilmGlumac filmGlumacEntity = new FilmGlumac();
                    filmGlumacEntity.FilmId = entity.Id;
                    filmGlumacEntity.FilmskaLicnostId = id;

                    Context.FilmGlumac.Add(filmGlumacEntity);
                }
            }

            Context.SaveChanges();

            FilmResponse response = Mapper.Map<Film, FilmResponse>(entity);
            return new PayloadResponse<FilmResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<FilmResponse> Update(int id, FilmUpsertRequest request)
        {
            Validator.ValidateEntityExists(id);

            if (request.ZanrId.HasValue)
                ZanrValidator.ValidateEntityExists(request.ZanrId.Value);
            if (request.RediteljId.HasValue)
                ZanrValidator.ValidateEntityExists(request.RediteljId.Value);
            if (request.FilmGlumacIds != null)
                FilmskaLicnostValidator.ValidateEntitiesExists(request.FilmGlumacIds);

            Film entity = Context.Set<Film>().Include(e => e.FilmGlumac).FirstOrDefault(e => e.Id == id);

            var filmGlumacForDelete = entity.FilmGlumac.Where(e => !request.FilmGlumacIds.Contains(e.FilmskaLicnostId)).ToList();
            Context.FilmGlumac.RemoveRange(filmGlumacForDelete);

            entity = Mapper.Map(request, entity);

            Context.Set<Film>().Update(entity);
            Context.SaveChanges();

            

            if (request.FilmGlumacIds != null)
            {
                foreach (var glumacId in request.FilmGlumacIds)
                {
                    FilmGlumac filmGlumacEntity = Context.FilmGlumac.FirstOrDefault(e => e.FilmId == entity.Id && e.FilmskaLicnostId == glumacId);

                    if(filmGlumacEntity == null)
                    {
                        filmGlumacEntity = new FilmGlumac();
                        filmGlumacEntity.FilmId = entity.Id;
                        filmGlumacEntity.FilmskaLicnostId = glumacId;

                        Context.FilmGlumac.Add(filmGlumacEntity);
                    }
                }
            }

            Context.SaveChanges();

            FilmResponse response = Mapper.Map<Film, FilmResponse>(entity);

            return new PayloadResponse<FilmResponse>(HttpStatusCode.OK, response);
        }
    }
}
