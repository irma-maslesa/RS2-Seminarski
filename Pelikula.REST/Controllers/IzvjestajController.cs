﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Izvjestaj;
using Pelikula.CORE.Filter;
using Pelikula.CORE.Helper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

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

    }
}
