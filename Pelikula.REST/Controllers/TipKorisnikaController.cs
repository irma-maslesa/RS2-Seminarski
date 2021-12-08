using Pelikula.API.Api;
using Pelikula.API.Model.TipKorisnika;

namespace API.Controllers
{
    public class TipKorisnikaController :
        CrudController<TipKorisnikaResponse, TipKorisnikaUpsertRequest, TipKorisnikaUpsertRequest>
    {
        public TipKorisnikaController(ITipKorisnikaService service) : base(service)
        {
        }
    }
}
