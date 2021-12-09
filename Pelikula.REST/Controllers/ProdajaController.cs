using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Prodaja;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace API.Controllers
{
    public class ProdajaController :
        CrudController<ProdajaResponse, ProdajaInsertRequest, object>
    {
        protected new readonly IProdajaService Service;

        public ProdajaController(IProdajaService service) : base(service)
        {
            Service = service;
        }

        [HttpGet]
        public override PagedPayloadResponse<ProdajaResponse> Get([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting)
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

            return Service.Get(paginationParams, filterParams, sortingParams);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("lov")]
        public override PagedPayloadResponse<LoV> GetLoVs([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting)
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

            return Service.GetLoVs(paginationParams, filterParams, sortingParams);
        }

        [HttpGet("{id}")]
        public override PayloadResponse<ProdajaResponse> GetById(int id)
        {
            return Service.GetById(id);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut("{id}")]
        public override PayloadResponse<ProdajaResponse> Update(int id, object dtoObject)
        {
            return Service.Update(id, dtoObject);
        }


    }
}
