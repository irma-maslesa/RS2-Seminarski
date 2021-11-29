using System;

namespace Pelikula.API.Model.Projekcija
{
    public partial class ProjekcijaTerminInsertRequest
    {
        public int ProjekcijaId { get; set; }
        public TimeSpan Termin { get; set; }
    }
}
