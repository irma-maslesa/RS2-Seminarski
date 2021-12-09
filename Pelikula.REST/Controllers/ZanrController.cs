using Pelikula.API.Api;
using Pelikula.API.Model.Zanr;

namespace API.Controllers
{
    public class ZanrController :
        CrudController<ZanrResponse, ZanrUpsertRequest, ZanrUpsertRequest>
    {
        public ZanrController(IZanrService service) : base(service)
        {
        }
    }
}
