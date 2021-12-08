namespace Pelikula.API.Model.Prodaja
{
    public partial class ProdajaRezervacijaInsertRequest
    {
        public int RezervacijaId { get; set; }
        public int ProdajaId { get; set; }
        public decimal Cijena { get; set; }
    }
}
