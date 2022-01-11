using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProjekcijaController :
        CrudController<ProjekcijaResponse, ProjekcijaUpsertRequest, ProjekcijaUpsertRequest>
    {
        protected new readonly IProjekcijaService Service;

        public ProjekcijaController(IProjekcijaService service) : base(service) {
            Service = service;
        }

        [Authorize]
        [HttpGet("aktivne")]
        public PagedPayloadResponse<ProjekcijaResponse> GetActive([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting) {
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

            return Service.GetActive(paginationParams, filterParams, sortingParams);
        }

        [Authorize]
        [HttpGet("{korisnickoIme}/preporucene")]
        public async Task<ListPayloadResponse<ProjekcijaResponse>> GetPreporucene(string korisnickoIme) {
            return await Service.GetPreporucene(korisnickoIme);
        }

        [Authorize]
        [HttpPost("{projekcijaId}/{korisnikId}")]
        public PayloadResponse<string> PosjetiProjekciju(int projekcijaId, int korisnikId) {
            return Service.PosjetiProjekciju(projekcijaId, korisnikId);
        }

        [Authorize]
        [HttpGet("{projekcijaId}/termini")]
        public ListPayloadResponse<LoV> GetTermine(int projekcijaId) {
            return Service.GetTermine(projekcijaId);
        }

        [Authorize]
        [HttpGet("{projekcijaId}/aktivni-termini")]
        public ListPayloadResponse<LoV> GetAktivneTermine(int projekcijaId) {
            return Service.GetAktivneTermine(projekcijaId);
        }

        [Authorize]
        [HttpGet("{projekcijaId}/aktivni-termini/{korisnikId}")]
        public ListPayloadResponse<LoV> GetAktivneTermineZaKorisnika(int projekcijaId, int korisnikId) {
            return Service.GetAktivneTermineZaKorisnika(projekcijaId, korisnikId);
        }

        [Authorize]
        [HttpGet("aktivne/details")]
        public PagedPayloadResponse<ProjekcijaDetailedResponse> GetDetailedActive([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting, string naziv, int? zanrId) {
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

            return Service.GetDetailedActive(paginationParams, filterParams, sortingParams, naziv, zanrId);
        }

        [Authorize]
        [HttpGet("comming-soon/details")]
        public PagedPayloadResponse<ProjekcijaDetailedResponse> GetDetailedComingSoon([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting, string naziv, int? zanrId) {
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

            return Service.GetDetailedComingSoon(paginationParams, filterParams, sortingParams, naziv, zanrId);
        }
    }
}
