using System;

namespace Pelikula.API.Model.Korisnik
{
    public partial class KorisnikRegistracijaRequest
    {
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Spol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string Lozinka { get; set; }
    }
}
