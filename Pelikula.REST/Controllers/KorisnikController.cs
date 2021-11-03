using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Pelikula.API.Api;
using Pelikula.API.Model.Korisnik;

namespace API.Controllers
{
    public class KorisnikController :
        CrudController<KorisnikResponse, KorisnikUpsertRequest, KorisnikUpsertRequest>
    {

        public KorisnikController(IKorisnikService KorisnikService) : base(KorisnikService)
        {
        }
    }
}
