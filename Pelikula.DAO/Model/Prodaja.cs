using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Prodaja
    {
        public Prodaja()
        {
            ProdajaArtikal = new HashSet<ProdajaArtikal>();
        }

        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public int KorisnikId { get; set; }
        public DateTime Datum { get; set; }
        public decimal Popust { get; set; }
        public decimal Porez { get; set; }
        public int? RezervacijaId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
        public virtual ICollection<ProdajaArtikal> ProdajaArtikal { get; set; }
    }
}
