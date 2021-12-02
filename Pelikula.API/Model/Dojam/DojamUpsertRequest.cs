using System;

namespace Pelikula.API.Model.Dojam
{
    public partial class DojamUpsertRequest
    {
        public int Ocjena { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public int KorisnikId { get; set; }
        public int ProjekcijaId { get; set; }
    }
}
