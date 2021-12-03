using Pelikula.API.Api;
using Pelikula.API.Model.Rezervacija;

namespace API.Controllers
{
    public class RezervacijaController :
        CrudController<RezervacijaResponse, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {

        public RezervacijaController(IRezervacijaService service) : base(service)
        {
        }
    }
}
