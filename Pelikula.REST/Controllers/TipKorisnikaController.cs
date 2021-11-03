using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.API.Model.TipKorisnika;

namespace API.Controllers
{
    public class TipKorisnikaController :
        CrudController<TipKorisnikaResponse, TipKorisnikaUpsertRequest, TipKorisnikaUpsertRequest>
    {

        public TipKorisnikaController(ITipKorisnikaService tipKorisnikaService) : base(tipKorisnikaService)
        {
        }
    }
}
