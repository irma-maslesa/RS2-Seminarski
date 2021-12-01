﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Database
{
    public partial class Prodaja
    {
        public Prodaja()
        {
            ProdajaArtikal = new HashSet<ProdajaArtikal>();
            ProdajaRezervacija = new HashSet<ProdajaRezervacija>();
        }

        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public int? KorisnikId { get; set; }
        public DateTime Datum { get; set; }
        public decimal? Popust { get; set; }
        public decimal? Porez { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<ProdajaArtikal> ProdajaArtikal { get; set; }
        public virtual ICollection<ProdajaRezervacija> ProdajaRezervacija { get; set; }
    }
}
