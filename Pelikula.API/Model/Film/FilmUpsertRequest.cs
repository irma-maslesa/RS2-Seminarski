using System.Collections.Generic;

namespace Pelikula.API.Model.Film
{
    public class FilmUpsertRequest
    {
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

        public List<int> FilmGlumacIds { get; set; }
    }
}
