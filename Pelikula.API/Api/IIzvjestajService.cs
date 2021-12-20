using Pelikula.API.Model.Izvjestaj;
using Pelikula.CORE.Helper.Response;
using System;

namespace Pelikula.API.Api
{
    public interface IIzvjestajService
    {
        ListPayloadResponse<IzvjestajProdajaPoDatumuResponse> GetProdajaPoDatumu(DateTime datumOd, DateTime datumDo);
        ListPayloadResponse<IzvjestajPrometUGodiniResponse> GetPrometUGodini(int? zanrId);

        ListPayloadResponse<IzvjestajOdnosOnlineInstore> GetOdnosOnlineInstore(DateTime? datumOd, DateTime? datumDo);

        ListPayloadResponse<IzvjestajTopKorisnici> GetTopKorisnici(int brojKorisnika, int? zanrId);


    }
}
