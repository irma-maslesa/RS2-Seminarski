using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Database
{
    public partial class Sjediste
    {
        public Sjediste()
        {
            SjedisteRezervacija = new HashSet<SjedisteRezervacija>();
        }

        public int Id { get; set; }
        public string Red { get; set; }
        public int? Broj { get; set; }
        public int? SalaId { get; set; }

        public virtual Sala Sala { get; set; }
        public virtual ICollection<SjedisteRezervacija> SjedisteRezervacija { get; set; }
    }
}
