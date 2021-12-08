using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class ProdajaArtikal
    {
        public int Id { get; set; }
        public int ProdajaId { get; set; }
        public int ArtikalId { get; set; }
        public int Kolicina { get; set; }

        public virtual Artikal Artikal { get; set; }
        public virtual Prodaja Prodaja { get; set; }
    }
}
