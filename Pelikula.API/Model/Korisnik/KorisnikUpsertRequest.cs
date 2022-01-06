using System;

namespace Pelikula.API.Model.Korisnik
{
    public class KorisnikUpsertRequest
    {
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Spol { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public virtual int TipKorisnikaId { get; set; }
    }
}
