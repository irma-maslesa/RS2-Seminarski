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

        [HttpGet("prodaja")]
        public ListPayloadResponse<IzvjestajProdajaPoDatumuResponse> GetProdajaPoDatumu([FromQuery] DateTime datumOd, [FromQuery] DateTime datumDo) {
            return Service.GetProdajaPoDatumu(datumOd, datumDo);
        }

        [HttpGet("promet")]
        public ListPayloadResponse<IzvjestajPrometUGodiniResponse> GetPrometUGodini([FromQuery] int? zanrId) {
            return Service.GetPrometUGodini(zanrId);
        }

        [HttpGet("odnos")]
        public ListPayloadResponse<IzvjestajOdnosOnlineInstore> GetOdnosOnlineInstore([FromQuery] DateTime? datumOd, [FromQuery] DateTime? datumDo) {
            return Service.GetOdnosOnlineInstore(datumOd, datumDo);
        }

        [HttpGet("top-korisnici")]
        public ListPayloadResponse<IzvjestajTopKorisnici> GetTopKorisnici([FromQuery] int? brojKorisnika, [FromQuery] int? zanrId) {
            return Service.GetTopKorisnici(brojKorisnika, zanrId);
        }

    }
}
