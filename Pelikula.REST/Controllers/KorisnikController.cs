using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    public class KorisnikController :
        CrudController<KorisnikResponse, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        protected new readonly IKorisnikService Service;

        public KorisnikController(IKorisnikService service) : base(service)
        {
            Service = service;
        }

        [HttpPost("registracija")]
        public virtual PayloadResponse<KorisnikResponse> Insert([FromBody] KorisnikRegistracijaRequest dtoObject)
        {
            return Service.Registracija(dtoObject);
        }

        [HttpGet("{projekcijaTerminId}/{bezRezervacije}/klijenti")]
        public virtual ListPayloadResponse<LoV> GetKlijentiForTermin(int projekcijaTerminId, bool bezRezervacije)
        {
            return Service.GetKlijentiForTermin(projekcijaTerminId, bezRezervacije);
        }
    }
}
