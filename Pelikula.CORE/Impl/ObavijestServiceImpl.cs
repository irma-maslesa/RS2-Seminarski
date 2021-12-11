using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Obavijest;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class ObavijestServiceImpl :
        CrudServiceImpl<ObavijestResponse, Obavijest, ObavijestUpsertRequest, ObavijestUpsertRequest>,
        IObavijestService
    {
        protected IKorisnikValidator KorisnikValidator { get; set; }

        public ObavijestServiceImpl(AppDbContext context, IMapper mapper, IObavijestValidator validator, IKorisnikValidator korisnikValidator) : base(context, mapper, validator) {
            KorisnikValidator = korisnikValidator;
        }

        public override PagedPayloadResponse<ObavijestResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
            IEnumerable<Obavijest> entityList = Context.Set<Obavijest>().Include(e => e.Korisnik).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Obavijest>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Obavijest>.SortData(sorting, entityList) : entityList;

            List<ObavijestResponse> responseList = Mapper.Map<List<ObavijestResponse>>(entityList);

            PaginationUtility.PagedData<ObavijestResponse> pagedResponse = PaginationUtility.Paginaion<ObavijestResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ObavijestResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ObavijestResponse> GetById(int id) {
            Validator.ValidateEntityExists(id);

            Obavijest entity = Context.Set<Obavijest>().Include(e => e.Korisnik).FirstOrDefault(e => e.Id == id);

            ObavijestResponse response = Mapper.Map<ObavijestResponse>(entity);

            return new PayloadResponse<ObavijestResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ObavijestResponse> Insert(ObavijestUpsertRequest request) {
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);

            Obavijest entity = Mapper.Map<ObavijestUpsertRequest, Obavijest>(request);
            entity = Context.Set<Obavijest>().Add(entity).Entity;

            Context.SaveChanges();

            ObavijestResponse response = Mapper.Map<Obavijest, ObavijestResponse>(entity);

            return new PayloadResponse<ObavijestResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ObavijestResponse> Update(int id, ObavijestUpsertRequest request) {
            Validator.ValidateEntityExists(id);
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);

            Obavijest entity = Context.Set<Obavijest>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Obavijest>().Update(entity);
            Context.SaveChanges();

            ObavijestResponse response = Mapper.Map<Obavijest, ObavijestResponse>(entity);

            return new PayloadResponse<ObavijestResponse>(HttpStatusCode.OK, response);
        }

    }
}
