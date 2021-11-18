using Pelikula.API.Model.TipKorisnika;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.API.Model.Korisnik
{
    public partial class KorisnikResponse
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Spol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public TipKorisnikaResponse TipKorisnika { get; set; }
    }
}
