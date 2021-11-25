using Pelikula.API.Model.TipKorisnika;
using System;

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
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public string Lozinka { get; set; }

        public TipKorisnikaResponse TipKorisnika { get; set; }
    }
}
