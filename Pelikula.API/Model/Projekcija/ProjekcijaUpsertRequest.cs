using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Projekcija
{
    public class ProjekcijaUpsertRequest
    {
        public int FilmId { get; set; }
        public int SalaId { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
        public DateTime VrijediOd { get; set; }
        public DateTime VrijediDo { get; set; }

        public List<ProjekcijaTerminUpsertRequest> ProjekcijaTermin { get; set; }
    }
}
