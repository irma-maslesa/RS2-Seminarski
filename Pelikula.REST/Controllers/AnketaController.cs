using Pelikula.API.Api;
using Pelikula.API.Model.Anketa;

namespace API.Controllers
{
    public class AnketaController :
        CrudController<AnketaResponse, AnketaUpsertRequest, AnketaUpsertRequest>
    {

        public AnketaController(IAnketaService tipKorisnikaService) : base(tipKorisnikaService)
        {
        }
    }
}
