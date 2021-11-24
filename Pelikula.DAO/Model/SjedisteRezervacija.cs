﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class SjedisteRezervacija
    {
        public int Id { get; set; }
        public int? SjedisteId { get; set; }
        public int? RezervacijaId { get; set; }
        public int? ProjekcijaTerminId { get; set; }

        public virtual ProjekcijaTermin ProjekcijaTermin { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
        public virtual Sjediste Sjediste { get; set; }
    }
}