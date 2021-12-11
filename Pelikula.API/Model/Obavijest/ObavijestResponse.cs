using System;

namespace Pelikula.API.Model.Obavijest
{
    public partial class ObavijestResponse
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public LoV Korisnik { get; set; }
    }
}
