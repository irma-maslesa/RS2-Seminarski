namespace Pelikula.API.Model.Artikal
{
    public class ArtikalResponse
    {

        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }

        public LoV JedinicaMjere { get; set; }
    }
}
