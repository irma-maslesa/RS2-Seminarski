using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Anketa
    {
        public Anketa() {
            AnketaOdgovor = new HashSet<AnketaOdgovor>();
        }

        public int Id { get; set; }
        public int KorisnikId { get; set; }
        public string Naslov { get; set; }
        public DateTime Datum { get; set; }
        public DateTime? ZakljucenoDatum { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<AnketaOdgovor> AnketaOdgovor { get; set; }
    }
}
