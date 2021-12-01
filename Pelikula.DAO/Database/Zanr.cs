using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Database
{
    public partial class Zanr
    {
        public Zanr()
        {
            Film = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Film> Film { get; set; }
    }
}
