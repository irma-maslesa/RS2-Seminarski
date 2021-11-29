using System;

namespace Pelikula.API.Model.Projekcija
{
    public partial class ProjekcijaTerminUpdateRequest
    {
        public int Id { get; set; }
        public int ProjekcijaId { get; set; }
        public TimeSpan Termin { get; set; }
    }
}
