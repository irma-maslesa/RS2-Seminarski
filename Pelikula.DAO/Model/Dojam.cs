using System;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Dojam
    {
        public int Id { get; set; }
        public int ProjekcijaId { get; set; }
        public int KorisnikId { get; set; }
        public int Ocjena { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Projekcija Projekcija { get; set; }
    }
}
