using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.API.Model.Zanr;

namespace API.Controllers
{
    public class ZanrController :
        CRUDController<ZanrResponse, ZanrSearchRequest, ZanrUpsertRequest, ZanrUpsertRequest>
    {

        public ZanrController(IZanrService zanrService) : base(zanrService)
        {
        }
    }
}
