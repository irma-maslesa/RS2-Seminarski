using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class FilmGlumac
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int FilmskaLicnostId { get; set; }

        public virtual Film Film { get; set; }
        public virtual FilmskaLicnost FilmskaLicnost { get; set; }
    }
}
