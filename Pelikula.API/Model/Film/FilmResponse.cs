using System.Collections.Generic;

namespace Pelikula.API.Model.Film
{
    public class FilmResponse
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public int? Trajanje { get; set; }
        public int? GodinaSnimanja { get; set; }
        public string Sadrzaj { get; set; }
        public string VideoLink { get; set; }
        public string ImdbLink { get; set; }
        public byte[] Plakat { get; set; }
        public byte[] PlakatThumb { get; set; }

        public LoV Reditelj { get; set; }
        public LoV Zanr { get; set; }
        public List<FilmGlumacResponse> Glumci { get; set; }
    }
}
