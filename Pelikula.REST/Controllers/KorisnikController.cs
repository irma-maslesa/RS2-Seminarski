using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;
using System;
using System.Text;

namespace API.Controllers
{
    public class KorisnikController :
        CrudController<KorisnikResponse, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        protected new readonly IKorisnikService Service;

        public KorisnikController(IKorisnikService service) : base(service) {
            Service = service;
        }

        [Authorize]
        [HttpGet("autentifikacija")]
        public virtual PayloadResponse<KorisnikResponse> Autentifikacija() {
            string authorization = HttpContext.Request.Headers["Authorization"];

            string encodedHeader = authorization["Basic ".Length..].Trim();

            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedHeader));

            int seperatorIndex = usernamePassword.IndexOf(':');

            return Service.Autentifikacija(usernamePassword.Substring(0, seperatorIndex), usernamePassword[(seperatorIndex + 1)..]);
        }

        [HttpPost("registracija")]
        public virtual PayloadResponse<KorisnikResponse> Insert([FromBody] KorisnikRegistracijaRequest dtoObject) {
            return Service.Registracija(dtoObject);
        }

        [Authorize]
        [HttpPut("uredi-profil/{id}")]
        public virtual PayloadResponse<KorisnikResponse> Update(int id, [FromBody] KorisnikRegistracijaRequest dtoObject) {
            return Service.UrediProfil(id, dtoObject);
        }

        [Authorize]
        [HttpGet("{projekcijaTerminId}/{bezRezervacije}/klijenti")]
        public virtual ListPayloadResponse<LoV> GetKlijentiForTermin(int projekcijaTerminId, bool bezRezervacije) {
            return Service.GetKlijentiForTermin(projekcijaTerminId, bezRezervacije);
        }
    }
}
