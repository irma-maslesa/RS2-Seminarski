using System;

namespace Pelikula.API.Model.Projekcija
{
    public partial class ProjekcijaTerminUpsertRequest
    {
        public int ProjekcijaId { get; set; }
        public DateTime Termin { get; set; }
    }
}
