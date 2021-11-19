using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Anketa
{
    public class AnketaUpdateRequest
    {
        public string Naslov { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? ZakljucenoDatum { get; set; }

        public int KorisnikId { get; set; }
        public List<AnketaOdgovorUpdateRequest> Odgovori { get; set; }
    }
}
