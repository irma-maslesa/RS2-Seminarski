using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Projekcija
{
    public partial class ProjekcijaTerminResponse
    {
        public int Id { get; set; }
        public DateTime? Termin { get; set; }

        public LoV Projekcija { get; set; }
    }
}
