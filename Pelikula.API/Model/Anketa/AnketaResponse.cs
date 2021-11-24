using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Anketa
{
    public class AnketaResponse
    {

        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? ZakljucenoDatum { get; set; }

        public virtual LoV Korisnik { get; set; }

        public List<AnketaOdgovorResponse> Odgovori { get; set; }
    }
}
