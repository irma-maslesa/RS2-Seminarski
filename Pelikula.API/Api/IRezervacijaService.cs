using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;

namespace Pelikula.API.Api
{
    public interface IRezervacijaService : ICrudService<RezervacijaResponse, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        PayloadResponse<RezervacijaResponse> GetByProjekcijaKorisnik(int projekcijaId, int korisnikId);
        PayloadResponse<RezervacijaResponse> Otkazi(int id);
    }
}
