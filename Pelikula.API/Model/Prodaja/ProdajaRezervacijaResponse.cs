using Pelikula.API.Model.Rezervacija;

namespace Pelikula.API.Model.Prodaja
{
    public partial class ProdajaRezervacijaResponse
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public RezervacijaResponse Rezervacija { get; set; }
    }
}
