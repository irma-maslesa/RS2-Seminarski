using Pelikula.API.Model.TipKorisnika;

namespace Pelikula.API.Api
{
    public interface ITipKorisnikaService : ICrudService<TipKorisnikaResponse, TipKorisnikaUpsertRequest, TipKorisnikaUpsertRequest>
    {
    }
}
