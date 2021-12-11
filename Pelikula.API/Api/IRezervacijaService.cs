using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;
using System.Collections.Generic;

namespace Pelikula.API.Api
{
    public interface IRezervacijaService : ICrudService<RezervacijaResponse, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        PayloadResponse<RezervacijaResponse> GetByProjekcijaKorisnik(int projekcijaId, int korisnikId);
        PayloadResponse<RezervacijaResponse> Otkazi(int id);
        PagedPayloadResponse<RezervacijaSimpleResponse> GetSimple(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting);
    }
}
