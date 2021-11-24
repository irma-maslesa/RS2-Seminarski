using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class Film
    {
        public Film()
        {
            FilmGlumac = new HashSet<FilmGlumac>();
            Projekcija = new HashSet<Projekcija>();
        }

        public int Id { get; set; }
        public string Naslov { get; set; }
        public int? Trajanje { get; set; }
        public int? GodinaSnimanja { get; set; }
        public string Sadrzaj { get; set; }
        public string VideoLink { get; set; }
        public string ImdbLink { get; set; }
        public byte[] Plakat { get; set; }
        public byte[] PlakatThumb { get; set; }
        public int? RediteljId { get; set; }
        public int? ZanrId { get; set; }

        public virtual FilmskaLicnost Reditelj { get; set; }
        public virtual Zanr Zanr { get; set; }
        public virtual ICollection<FilmGlumac> FilmGlumac { get; set; }
        public virtual ICollection<Projekcija> Projekcija { get; set; }
    }
}
