using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Database
{
    public partial class ProdajaRezervacija
    {
        public int Id { get; set; }
        public int ProdajaId { get; set; }
        public int RezervacijaId { get; set; }
        public decimal Cijena { get; set; }

        public virtual Prodaja Prodaja { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
