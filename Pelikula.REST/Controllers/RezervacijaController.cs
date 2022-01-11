using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace API.Controllers
{
    public class RezervacijaController :
        CrudController<RezervacijaResponse, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        protected new readonly IRezervacijaService Service;

        public RezervacijaController(IRezervacijaService service) : base(service) {
            Service = service;
        }

        [Authorize]
        [HttpPut("{id}/otkazi")]
        public virtual PayloadResponse<RezervacijaResponse> Otkazi(int id) {
            return Service.Otkazi(id);
        }

        [Authorize]
        [HttpGet("simple")]
        public virtual PagedPayloadResponse<RezervacijaSimpleResponse> GetSimple([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting) {
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

            return Service.GetSimple(paginationParams, filterParams, sortingParams);
        }

        [Authorize]
        [HttpGet("not-prodaja")]
        public virtual PagedPayloadResponse<RezervacijaResponse> GetNotProdaja([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting) {
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

            return Service.GetNotProdaja(paginationParams, filterParams, sortingParams);
        }
    }
}
