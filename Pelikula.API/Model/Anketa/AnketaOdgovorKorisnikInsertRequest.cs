using System;

namespace Pelikula.API.Model.Anketa
{
    public class AnketaOdgovorKorisnikInsertRequest
    {
        public int AnketaOdgovorId { get; set; }

        public int KorisnikId { get; set; }
    }
}

