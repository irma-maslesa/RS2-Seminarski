using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class ProjekcijaTermin
    {
        public ProjekcijaTermin() {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public int ProjekcijaId { get; set; }
        public DateTime Termin { get; set; }

        public virtual Projekcija Projekcija { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
