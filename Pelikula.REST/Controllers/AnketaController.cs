using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace API.Controllers
{
    public class AnketaController :
        CrudController<AnketaResponse, AnketaInsertRequest, AnketaUpdateRequest>
    {
        protected new readonly IAnketaService Service;

        public AnketaController(IAnketaService service) : base(service)
        {
            Service = service;
        }

        [HttpPost("korisnik-odgovor")]
        public PayloadResponse<AnketaExtendedResponse> InsertKorisnikOdgovor([FromBody] AnketaOdgovorKorisnikInsertRequest dtoObject)
        {
            return Service.InsertKorisnikOdgovor(dtoObject);
        }

        [HttpPut("{id}/zatvori")]
        public PayloadResponse<AnketaResponse> Close(int id)
        {
            return Service.Close(id);
        }

        [HttpGet("aktivne")]
        public PagedPayloadResponse<AnketaResponse> GetActive([FromQuery] int? korisnikId, [FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting)
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

            return Service.GetActive(korisnikId, paginationParams, filterParams, sortingParams);
        }

        [HttpGet("korisnik/{id}")]
        public PagedPayloadResponse<AnketaExtendedResponse> GetForUser(int id, [FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting)
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

            return Service.GetForUser(id, paginationParams, filterParams, sortingParams);
        }

    }
}
