using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReadController<ResponseDTO> :
        ControllerBase
        where ResponseDTO : class
    {
        protected readonly IReadService<ResponseDTO> Service;

        public ReadController(IReadService<ResponseDTO> service) {
            Service = service;
        }

        [Authorize]
        [HttpGet]
        public virtual PagedPayloadResponse<ResponseDTO> Get([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting) {
            StringBuilder stringBuilder = new StringBuilder();
            PaginationUtility.PaginationParams paginationParams = new PaginationUtility.PaginationParams();
            IEnumerable<FilterUtility.FilterParams> filterParams = new List<FilterUtility.FilterParams>();
            IEnumerable<SortingUtility.SortingParams> sortingParams = new List<SortingUtility.SortingParams>();

            try {
                paginationParams = pagination != null ? JsonConvert.DeserializeObject<PaginationUtility.PaginationParams>(pagination) : null;
            }
            catch (System.Exception) {
                stringBuilder.Append("Paginacija - Neispravan JSON format. ");
            }
            try {
                filterParams = filter != null && filter.Any() ? JsonConvert.DeserializeObject<IEnumerable<FilterUtility.FilterParams>>(filter) : null;
            }
            catch (System.Exception) {
                stringBuilder.Append("Filter - Neispravan JSON format. ");
            }
            try {
                sortingParams = sorting != null && sorting.Any() ? JsonConvert.DeserializeObject<IEnumerable<SortingUtility.SortingParams>>(sorting) : null;
            }
            catch (System.Exception) {
                stringBuilder.Append("Sorting - Neispravan JSON format. ");
            }

            if (stringBuilder.ToString().Any()) {
                throw new UserException(stringBuilder.ToString(), HttpStatusCode.BadRequest);
            }

            return Service.Get(paginationParams, filterParams, sortingParams);
        }

        [Authorize]
        [HttpGet("lov")]
        public virtual PagedPayloadResponse<LoV> GetLoVs([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting) {
            StringBuilder stringBuilder = new StringBuilder();
            PaginationUtility.PaginationParams paginationParams = new PaginationUtility.PaginationParams();
            IEnumerable<FilterUtility.FilterParams> filterParams = new List<FilterUtility.FilterParams>();
            IEnumerable<SortingUtility.SortingParams> sortingParams = new List<SortingUtility.SortingParams>();

            try {
                paginationParams = pagination != null ? JsonConvert.DeserializeObject<PaginationUtility.PaginationParams>(pagination) : null;
            }
            catch (System.Exception) {
                stringBuilder.Append("Paginacija - Neispravan JSON format. ");
            }
            try {
                filterParams = filter != null && filter.Any() ? JsonConvert.DeserializeObject<IEnumerable<FilterUtility.FilterParams>>(filter) : null;
            }
            catch (System.Exception) {
                stringBuilder.Append("Filter - Neispravan JSON format. ");
            }
            try {
                sortingParams = sorting != null && sorting.Any() ? JsonConvert.DeserializeObject<IEnumerable<SortingUtility.SortingParams>>(sorting) : null;
            }
            catch (System.Exception) {
                stringBuilder.Append("Sorting - Neispravan JSON format. ");
            }

            if (stringBuilder.ToString().Any()) {
                throw new UserException(stringBuilder.ToString(), HttpStatusCode.BadRequest);
            }

            return Service.GetLoVs(paginationParams, filterParams, sortingParams);
        }

        [Authorize]
        [HttpGet("{id}")]
        public virtual PayloadResponse<ResponseDTO> GetById(int id) {
            return Service.GetById(id);
        }
    }
}
