using Pelikula.API.Model;
using Pelikula.API.Model.Korisnik;
using Pelikula.CORE.Helper.Response;
using System.Threading.Tasks;

namespace Pelikula.API.Api
{
    public interface IKorisnikService : ICrudService<KorisnikResponse, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
        Task<PayloadResponse<KorisnikResponse>> Autentifikacija(string korisnickoIme, string lozinka);
        PayloadResponse<KorisnikResponse> Registracija(KorisnikRegistracijaRequest request);
        ListPayloadResponse<LoV> GetKlijentiForTermin(int projekcijaTerminId, bool bezRezervacije);
    }
}
