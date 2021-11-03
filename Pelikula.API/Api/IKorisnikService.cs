using Pelikula.API.Model.Korisnik;

namespace Pelikula.API.Api
{
    public interface IKorisnikService : ICrudService<KorisnikResponse, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {
    }
}
