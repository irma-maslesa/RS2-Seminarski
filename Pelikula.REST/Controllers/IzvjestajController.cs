using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Model.Izvjestaj;
using Pelikula.CORE.Helper.Response;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IzvjestajController :
        ControllerBase
    {
        protected readonly IIzvjestajService Service;

        public IzvjestajController(IIzvjestajService service) {
            Service = service;
        }

        [Authorize]
        [HttpGet("prodaja")]
        public ListPayloadResponse<IzvjestajProdajaPoDatumuResponse> GetProdajaPoDatumu([FromQuery] DateTime datumOd, [FromQuery] DateTime datumDo) {
            return Service.GetProdajaPoDatumu(datumOd, datumDo);
        }

        [Authorize]
        [HttpGet("promet")]
        public ListPayloadResponse<IzvjestajPrometUGodiniResponse> GetPrometUGodini([FromQuery] int? zanrId) {
            return Service.GetPrometUGodini(zanrId);
        }

        [Authorize]
        [HttpGet("odnos")]
        public ListPayloadResponse<IzvjestajOdnosOnlineInstore> GetOdnosOnlineInstore([FromQuery] DateTime? datumOd, [FromQuery] DateTime? datumDo) {
            return Service.GetOdnosOnlineInstore(datumOd, datumDo);
        }

        [Authorize]
        [HttpGet("top-korisnici")]
        public ListPayloadResponse<IzvjestajTopKorisnici> GetTopKorisnici([FromQuery] int brojKorisnika, [FromQuery] int? zanrId) {
            return Service.GetTopKorisnici(brojKorisnika, zanrId);
        }

    }
}
