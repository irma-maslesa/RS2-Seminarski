using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Database
{
    public partial class AnketaOdgovorKorisnik
    {
        public int Id { get; set; }
        public int AnketaOdgovorId { get; set; }
        public int KorisnikId { get; set; }
        public DateTime Datum { get; set; }

        public virtual AnketaOdgovor AnketaOdgovor { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
