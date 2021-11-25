namespace Pelikula.API.Model.Artikal
{
    public class ArtikalUpsertRequest
    {
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public byte[] Slika { get; set; } = null;
        public byte[] SlikaThumb { get; set; } = null;

        public int JedinicaMjereId { get; set; }
    }
}
