using Pelikula.API.Api;
using Pelikula.API.Model.Sala;

namespace API.Controllers
{
    public class SalaController :
        CrudController<SalaResponse, SalaUpsertRequest, SalaUpsertRequest>
    {

        public SalaController(ISalaService jedinicaMjereService) : base(jedinicaMjereService)
        {
        }
    }
}
