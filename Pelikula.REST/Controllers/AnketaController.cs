using Pelikula.API.Api;
using Pelikula.API.Model.Anketa;

namespace API.Controllers
{
    public class AnketaController :
        CrudController<AnketaResponse, AnketaInsertRequest, AnketaUpdateRequest>
    {

        public AnketaController(IAnketaService tipKorisnikaService) : base(tipKorisnikaService)
        {
        }
    }
}
