using Pelikula.API.Model.Artikal;

namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaArtikalResponse
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }

        public ArtikalResponse Artikal { get; set; }
    }
}
