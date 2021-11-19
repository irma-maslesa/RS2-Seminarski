using Pelikula.API.Api;
using Pelikula.API.Model.JedinicaMjere;

namespace API.Controllers
{
    public class JedinicaMjereController :
        CrudController<JedinicaMjereResponse, JedinicaMjereUpsertRequest, JedinicaMjereUpsertRequest>
    {

        public JedinicaMjereController(IJedinicaMjereService jedinicaMjereService) : base(jedinicaMjereService)
        {
        }
    }
}
