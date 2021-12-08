using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Helper;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Pelikula.API.Model;

namespace API.Controllers
{
    public class ProjekcijaController :
        CrudController<ProjekcijaResponse, ProjekcijaUpsertRequest, ProjekcijaUpsertRequest>
    {
        protected readonly IProjekcijaService Service;

        public ProjekcijaController(IProjekcijaService service) : base(service)
        {
            Service = service;
        }

        [HttpGet("aktivne")]
        public PagedPayloadResponse<ProjekcijaResponse> GetActive([FromQuery] string pagination, [FromQuery] string filter, [FromQuery] string sorting)
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

            return Service.GetActive(paginationParams, filterParams, sortingParams);
        }

        [HttpGet("{korisnickoIme}/preporucene")]
        public async Task<ListPayloadResponse<ProjekcijaResponse>> GetPreporucene(string korisnickoIme)
        {
            return await Service.GetPreporucene(korisnickoIme);
        }

        [HttpPost("{projekcijaId}/{korisnikId}")]
        public PayloadResponse<string> PosjetiProjekciju(int projekcijaId, int korisnikId)
        {
            return Service.PosjetiProjekciju(projekcijaId, korisnikId);
        }

        [HttpGet("{projekcijaId}/termini")]
        public ListPayloadResponse<LoV> GetTermine(int projekcijaId)
        {
            return Service.GetTermine(projekcijaId);
        }

        [HttpGet("{projekcijaId}/aktivni-termini")]
        public ListPayloadResponse<LoV> GetAktivneTermine(int projekcijaId)
        {
            return Service.GetAktivneTermine(projekcijaId);
        }

    }
}
