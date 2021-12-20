using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class FilmskaLicnost
    {
        public FilmskaLicnost() {
            Film = new HashSet<Film>();
            FilmGlumac = new HashSet<FilmGlumac>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool IsReziser { get; set; }
        public bool IsGlumac { get; set; }

        public virtual ICollection<Film> Film { get; set; }
        public virtual ICollection<FilmGlumac> FilmGlumac { get; set; }
    }
}
