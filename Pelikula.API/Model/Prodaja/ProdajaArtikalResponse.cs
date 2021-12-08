namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaArtikalResponse
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }

        public LoV Artikal { get; set; }
    }
}
