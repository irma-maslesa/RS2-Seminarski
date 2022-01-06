using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Artikal
    {
        public Artikal()
        {
            ProdajaArtikal = new HashSet<ProdajaArtikal>();
        }

        public int Id { get; set; }
        public int JedinicaMjereId { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public virtual JedinicaMjere JedinicaMjere { get; set; }
        public virtual ICollection<ProdajaArtikal> ProdajaArtikal { get; set; }
    }
}
