using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.CORE.Helper.Response;
using Pelikula.API.Model.Helper;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using Pelikula.CORE.Filter;
using System.Net;
using Pelikula.API.Model;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadController<ResponseDTO> :
        ControllerBase
        where ResponseDTO : class
    {
        protected readonly IReadService<ResponseDTO> readService;

        public ReadController(IReadService<ResponseDTO> readService)
        {
            this.readService = readService;
        }

        [HttpGet]
        public virtual PagedPayloadResponse<ResponseDTO> Get([FromQuery] string pagination, [FromQuery]  string filter, [FromQuery] string sorting)
        {
            StringBuilder stringBuilder = new StringBuilder();
            PaginationUtility.PaginationParams paginationParams = new PaginationUtility.PaginationParams();
            IEnumerable<FilterUtility.FilterParams> filterParams = new List<FilterUtility.FilterParams>();
            IEnumerable<SortingUtility.SortingParams> sortingParams = new List<SortingUtility.SortingParams>();

            try
            {
                paginationParams = pagination != null ? JsonConvert.DeserializeObject<PaginationUtility.PaginationParams>(pagination) : null;
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Paginacija - Neispravan JSON format. ");
            }
            try
            {
                filterParams = filter != null && filter.Any()? JsonConvert.DeserializeObject<IEnumerable<FilterUtility.FilterParams>>(filter):null;
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Filter - Neispravan JSON format. ");
            }
            try
            {
                sortingParams = sorting != null && sorting.Any() ?  JsonConvert.DeserializeObject<IEnumerable<SortingUtility.SortingParams>>(sorting):null;
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Sorting - Neispravan JSON format. ");
            }

            if (stringBuilder.ToString().Any())
            {
                throw new UserException(stringBuilder.ToString(), HttpStatusCode.BadRequest);
            }
            
            return readService.Get(paginationParams, filterParams, sortingParams);
        }

        [HttpGet("lov")]
        public virtual PagedPayloadResponse<LoV> GetLoVs([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting)
        {
            StringBuilder stringBuilder = new StringBuilder();
            PaginationUtility.PaginationParams paginationParams = new PaginationUtility.PaginationParams();
            IEnumerable<FilterUtility.FilterParams> filterParams = new List<FilterUtility.FilterParams>();
            IEnumerable<SortingUtility.SortingParams> sortingParams = new List<SortingUtility.SortingParams>();

            try
            {
                paginationParams = pagination != null ? JsonConvert.DeserializeObject<PaginationUtility.PaginationParams>(pagination) : null;
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Paginacija - Neispravan JSON format. ");
            }
            try
            {
                filterParams = filter != null && filter.Any() ? JsonConvert.DeserializeObject<IEnumerable<FilterUtility.FilterParams>>(filter) : null;
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Filter - Neispravan JSON format. ");
            }
            try
            {
                sortingParams = sorting != null && sorting.Any() ? JsonConvert.DeserializeObject<IEnumerable<SortingUtility.SortingParams>>(sorting) : null;
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Sorting - Neispravan JSON format. ");
            }

            if (stringBuilder.ToString().Any())
            {
                throw new UserException(stringBuilder.ToString(), HttpStatusCode.BadRequest);
            }

            return readService.GetLoVs(paginationParams, filterParams, sortingParams);
        }

        [HttpGet("{id}")]
        public virtual PayloadResponse<ResponseDTO> GetById(int id)
        {
            return readService.GetById(id);
        }
    }
}
