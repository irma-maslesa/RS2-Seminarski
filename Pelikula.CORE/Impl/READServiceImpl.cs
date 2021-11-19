using AutoMapper;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class ReadServiceImpl<ResponseDTO, Entity> :
        IReadService<ResponseDTO>
        where ResponseDTO : class
        where Entity : class
    {
        protected AppDbContext Context { get; set; }
        protected readonly IMapper Mapper;
        protected readonly IBaseValidator<Entity> Validator;

        public ReadServiceImpl(AppDbContext context, IMapper mapper, IBaseValidator<Entity> validator)
        {
            Context = context;
            Mapper = mapper;
            Validator = validator;
        }

        public virtual PagedPayloadResponse<ResponseDTO> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Entity> entityList = Context.Set<Entity>().ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Entity>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Entity>.SortData(sorting, entityList) : entityList;

            List<ResponseDTO> responseList = Mapper.Map<List<ResponseDTO>>(entityList);

            PaginationUtility.PagedData<ResponseDTO> pagedResponse = PaginationUtility.Paginaion<ResponseDTO>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ResponseDTO>(HttpStatusCode.OK, pagedResponse);
        }
        public virtual PayloadResponse<ResponseDTO> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Entity entity = Context.Set<Entity>().Find(id);

            ResponseDTO response = Mapper.Map<ResponseDTO>(entity);

            return new PayloadResponse<ResponseDTO>(HttpStatusCode.OK, response);
        }

        public virtual PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Entity> entityList = Context.Set<Entity>().ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Entity>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Entity>.SortData(sorting, entityList) : entityList;

            List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

            PaginationUtility.PagedData<LoV> pagedResponse = PaginationUtility.Paginaion<LoV>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<LoV>(HttpStatusCode.OK, pagedResponse);
        }
    }
}
