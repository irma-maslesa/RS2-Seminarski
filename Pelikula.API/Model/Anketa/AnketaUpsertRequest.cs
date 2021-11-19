using System;

namespace Pelikula.API.Model.Anketa
{
    public class AnketaUpsertRequest
    {
        public string Naslov { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? ZakljucenoDatum { get; set; }

        public int KorisnikId { get; set; }
    }
}
