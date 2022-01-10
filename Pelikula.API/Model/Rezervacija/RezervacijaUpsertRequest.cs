using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Rezervacija
{
    public class RezervacijaUpsertRequest
    {
        public int BrojSjedista { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? DatumProdano { get; set; }
        public DateTime? DatumOtkazano { get; set; }

        public int KorisnikId { get; set; }
        public int ProjekcijaTerminId { get; set; }
        public ICollection<int> SjedistaIds { get; set; }
    }
}
