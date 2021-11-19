using System;

namespace Pelikula.API.Model.Obavijest
{
    public partial class ObavijestUpsertRequest
    {
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public int KorisnikId { get; set; }
    }
}
