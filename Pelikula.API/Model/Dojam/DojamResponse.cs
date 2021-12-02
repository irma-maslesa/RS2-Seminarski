using System;

namespace Pelikula.API.Model.Dojam
{
    public partial class DojamResponse
    {
        public int Id { get; set; }
        public int Ocjena { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public LoV Korisnik { get; set; }
        public LoV Projekcija { get; set; }
    }
}
