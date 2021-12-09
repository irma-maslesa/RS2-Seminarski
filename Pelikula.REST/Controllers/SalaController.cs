using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Sala;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    public class SalaController :
        CrudController<SalaResponse, SalaUpsertRequest, SalaUpsertRequest>
    {
        protected new readonly ISalaService Service;

        public SalaController(ISalaService service) : base(service)
        {
            Service = service;
        }

        [HttpGet("{projekcijaTerminId}/zauzeta-sjedista")]
        public ListPayloadResponse<LoV> GetZauzetaSjedista(int projekcijaTerminId)
        {
            return Service.GetZauzetaSjedista(projekcijaTerminId);
        }

        [HttpGet("{projekcijaId}/sjedista")]
        public ListPayloadResponse<LoV> GetSjedista(int projekcijaId)
        {
            return Service.GetSjedista(projekcijaId);
        }
    }
}
