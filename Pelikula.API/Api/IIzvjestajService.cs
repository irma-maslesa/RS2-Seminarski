﻿using Pelikula.API.Model.Izvjestaj;
using Pelikula.CORE.Helper.Response;
using System;

namespace Pelikula.API.Api
{
    public interface IIzvjestajService
    {
        ListPayloadResponse<IzvjestajProdajaPoDatumuResponse> GetProdajaPoDatumu(DateTime datumOd, DateTime datumDo);
    }
}