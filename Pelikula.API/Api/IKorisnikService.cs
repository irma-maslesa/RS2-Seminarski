using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO.Model;

namespace Pelikula.API.Api
{
    public interface IKorisnikService : ICrudService<KorisnikResponse, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        PayloadResponse<KorisnikResponse> Autentifikacija(string korisnickoIme, string lozinka);
        PayloadResponse<KorisnikResponse> Registracija(KorisnikRegistracijaRequest request);
    }
}
