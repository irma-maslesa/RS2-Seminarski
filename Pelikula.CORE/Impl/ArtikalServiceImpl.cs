using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Artikal;
using Pelikula.API.Model.Helper;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class ArtikalServiceImpl :
        CrudServiceImpl<ArtikalResponse, Artikal, ArtikalUpsertRequest, ArtikalUpsertRequest>,
        IArtikalService
    {
        protected IJedinicaMjereValidator JedinicaMjereValidator { get; set; }

        public ArtikalServiceImpl(AppDbContext context, IMapper mapper, IArtikalValidator validator, IJedinicaMjereValidator korisnikValidator) : base(context, mapper, validator) {
            JedinicaMjereValidator = korisnikValidator;
        }

        public override PagedPayloadResponse<ArtikalResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Artikal> entityList = Context.Set<Artikal>().Include(e => e.JedinicaMjere).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Artikal>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Artikal>.SortData(sorting, entityList) : entityList;

            List<ArtikalResponse> responseList = Mapper.Map<List<ArtikalResponse>>(entityList);

            PaginationUtility.PagedData<ArtikalResponse> pagedResponse = PaginationUtility.Paginaion<ArtikalResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ArtikalResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ArtikalResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Artikal entity = Context.Set<Artikal>().Include(e => e.JedinicaMjere).FirstOrDefault(e => e.Id == id);

            ArtikalResponse response = Mapper.Map<ArtikalResponse>(entity);

            return new PayloadResponse<ArtikalResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ArtikalResponse> Insert(ArtikalUpsertRequest request) {
            JedinicaMjereValidator.ValidateEntityExists(request.JedinicaMjereId);

            Artikal entity = Mapper.Map<ArtikalUpsertRequest, Artikal>(request);
            entity.Sifra = GenerateSifra();

            entity = Context.Set<Artikal>().Add(entity).Entity;

            Context.SaveChanges();

            ArtikalResponse response = Mapper.Map<Artikal, ArtikalResponse>(entity);
            return new PayloadResponse<ArtikalResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ArtikalResponse> Update(int id, ArtikalUpsertRequest request) {
            Validator.ValidateEntityExists(id);
            JedinicaMjereValidator.ValidateEntityExists(request.JedinicaMjereId);

            Artikal entity = Context.Set<Artikal>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Artikal>().Update(entity);
            Context.SaveChanges();

            ArtikalResponse response = Mapper.Map<Artikal, ArtikalResponse>(entity);

            return new PayloadResponse<ArtikalResponse>(HttpStatusCode.OK, response);
        }

        private string GenerateSifra() {

            var najvecaSifra = Context.Artikal
                .OrderByDescending(e => e.Sifra)
                .Select(e => e.Sifra)
                .FirstOrDefault();

            if (najvecaSifra != null) {
                if (int.TryParse(najvecaSifra, out int sifra))
                    return string.Format("{0:D6}", ++sifra);
                else
                    throw new UserException("Nemoguće postavljanje šifre!", HttpStatusCode.BadRequest);
            }
            else {
                return string.Format("{0:D6}", 1);
            }
        }

    }
}
