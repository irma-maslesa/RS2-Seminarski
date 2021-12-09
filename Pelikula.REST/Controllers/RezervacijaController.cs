using Microsoft.AspNetCore.Mvc;
using Pelikula.API.Api;
using Pelikula.API.Model.Rezervacija;
using Pelikula.CORE.Helper.Response;

namespace API.Controllers
{
    public class RezervacijaController :
        CrudController<RezervacijaResponse, RezervacijaUpsertRequest, RezervacijaUpsertRequest>
    {
        protected new readonly IRezervacijaService Service;

        public RezervacijaController(IRezervacijaService service) : base(service)
        {
            Service = service;
        }

        [HttpPut("{id}/otkazi")]
        public virtual PayloadResponse<RezervacijaResponse> Otkazi(int id)
        {
            return Service.Otkazi(id);
        }
    }
}
