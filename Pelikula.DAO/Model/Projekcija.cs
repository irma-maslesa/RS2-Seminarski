using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Projekcija
    {
        public Projekcija()
        {
            Dojam = new HashSet<Dojam>();
            ProjekcijaKorisnik = new HashSet<ProjekcijaKorisnik>();
            ProjekcijaTermin = new HashSet<ProjekcijaTermin>();
        }

        public int Id { get; set; }
        public int FilmId { get; set; }
        public int SalaId { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
        public DateTime VrijediOd { get; set; }
        public DateTime VrijediDo { get; set; }

        public virtual Film Film { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual ICollection<Dojam> Dojam { get; set; }
        public virtual ICollection<ProjekcijaKorisnik> ProjekcijaKorisnik { get; set; }
        public virtual ICollection<ProjekcijaTermin> ProjekcijaTermin { get; set; }
    }
}
