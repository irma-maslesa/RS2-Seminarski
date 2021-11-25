using Pelikula.API.Api;
using Pelikula.API.Model.Artikal;

namespace API.Controllers
{
    public class ArtikalController :
        CrudController<ArtikalResponse, ArtikalUpsertRequest, ArtikalUpsertRequest>
    {

        public ArtikalController(IArtikalService jedinicaMjereService) : base(jedinicaMjereService)
        {
        }
    }
}
