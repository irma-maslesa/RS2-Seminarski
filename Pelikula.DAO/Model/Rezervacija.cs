using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Rezervacija
    {
        public Rezervacija()
        {
            Prodaja = new HashSet<Prodaja>();
            SjedisteRezervacija = new HashSet<SjedisteRezervacija>();
        }

        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public int BrojSjedista { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumProjekcije { get; set; }
        public DateTime? DatumProdano { get; set; }
        public DateTime? DatumOtkazano { get; set; }
        public int ProjekcijaTerminId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ProjekcijaTermin ProjekcijaTermin { get; set; }
        public virtual ICollection<Prodaja> Prodaja { get; set; }
        public virtual ICollection<SjedisteRezervacija> SjedisteRezervacija { get; set; }
    }
}
