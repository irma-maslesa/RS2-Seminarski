using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Sala
    {
        public Sala()
        {
            Projekcija = new HashSet<Projekcija>();
            Sjediste = new HashSet<Sjediste>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int BrojSjedista { get; set; }
        public int BrojSjedistaDuzina { get; set; }
        public int BrojSjedistaSirina { get; set; }

        public virtual ICollection<Projekcija> Projekcija { get; set; }
        public virtual ICollection<Sjediste> Sjediste { get; set; }
    }
}
