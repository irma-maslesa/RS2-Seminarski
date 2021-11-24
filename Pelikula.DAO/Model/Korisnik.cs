using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Anketa = new HashSet<Anketa>();
            AnketaOdgovorKorisnik = new HashSet<AnketaOdgovorKorisnik>();
            Dojam = new HashSet<Dojam>();
            Obavijest = new HashSet<Obavijest>();
            Prodaja = new HashSet<Prodaja>();
            ProjekcijaKorisnik = new HashSet<ProjekcijaKorisnik>();
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public int TipKorisnikaId { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Spol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public virtual TipKorisnika TipKorisnika { get; set; }
        public virtual ICollection<Anketa> Anketa { get; set; }
        public virtual ICollection<AnketaOdgovorKorisnik> AnketaOdgovorKorisnik { get; set; }
        public virtual ICollection<Dojam> Dojam { get; set; }
        public virtual ICollection<Obavijest> Obavijest { get; set; }
        public virtual ICollection<Prodaja> Prodaja { get; set; }
        public virtual ICollection<ProjekcijaKorisnik> ProjekcijaKorisnik { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
