namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaArtikalInsertRequest
    {
        public int ArtikalId { get; set; }
        public int ProdajaId { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
    }
}
