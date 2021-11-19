using System;
using System.Collections.Generic;

namespace Pelikula.DAO.Model
{
    public partial class AnketaOdgovor
    {
        public AnketaOdgovor()
        {
            //AnketaOdgovorKorisnik = new HashSet<AnketaOdgovorKorisnik>();
        }

        public int Id { get; set; }
        public int AnketaId { get; set; }
        public string Odgovor { get; set; }
        public int RedniBroj { get; set; }
        public int UkupnoIzabrano { get; set; }

        public virtual Anketa Anketa { get; set; }
        //public virtual ICollection<AnketaOdgovorKorisnik> AnketaOdgovorKorisnik { get; set; }
    }
}
