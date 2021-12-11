using Pelikula.API.Api;
using Pelikula.API.Model.Obavijest;

namespace API.Controllers
{
    public class ObavijestController :
        CrudController<ObavijestResponse, ObavijestUpsertRequest, ObavijestUpsertRequest>
    {
        public ObavijestController(IObavijestService service) : base(service) {
        }
    }
}
