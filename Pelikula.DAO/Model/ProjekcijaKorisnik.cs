using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class ProjekcijaKorisnik
    {
        public int Id { get; set; }
        public int ProjekcijaId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime DatumPosjete { get; set; }
        public DateTime DatumPosljednjePosjete { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Projekcija Projekcija { get; set; }
    }
}
