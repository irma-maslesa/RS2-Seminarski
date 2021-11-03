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
using System.ComponentModel;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReadController<ResponseDTO, SearchDTO> :
        ControllerBase
        where ResponseDTO : class
        where SearchDTO : class
    {
        protected readonly IReadService<ResponseDTO, SearchDTO> readService;

        public ReadController(IReadService<ResponseDTO, SearchDTO> readService)
        {
            this.readService = readService;
        }

        [HttpGet]
        public virtual PagedPayloadResponse<ResponseDTO> Get([FromQuery] string pagination, [FromQuery, Description("someDesc")]  List<string> filter, [FromQuery] List<string> sorting)
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
                filterParams = JsonConvert.DeserializeObject<IEnumerable<FilterUtility.FilterParams>>($"[{string.Join(",", filter)}]");
            }
            catch (System.Exception)
            {
                stringBuilder.Append("Filter - Neispravan JSON format. ");
            }
            try
            {
                sortingParams = JsonConvert.DeserializeObject<IEnumerable<SortingUtility.SortingParams>>($"[{string.Join(",", sorting)}]");
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

        [HttpGet("{id}")]
        public virtual PayloadResponse<ResponseDTO> GetById(int id)
        {
            return readService.GetById(id);
        }
    }
}
