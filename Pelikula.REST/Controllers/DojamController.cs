using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Model.Dojam;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    public class DojamController :
        CrudController<DojamResponse, DojamUpsertRequest, DojamUpsertRequest>
    {
        protected readonly IDojamService Service;

        public DojamController(IDojamService service) : base(service)
        {
            Service = service;
        }

        [HttpGet("{projekcijaId}/{korisnikId}")]
        public PayloadResponse<DojamResponse> GetByProjekcijaKorisnik(int projekcijaId, int korisnikId)
        {
            return Service.GetByProjekcijaKorisnik(projekcijaId, korisnikId);
        }
    }
}
