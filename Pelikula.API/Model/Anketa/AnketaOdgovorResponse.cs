namespace Pelikula.API.Model.Anketa
{
    public partial class AnketaOdgovorResponse
    {
        public int Id { get; set; }
        public string Odgovor { get; set; }
        public int RedniBroj { get; set; }
        public int UkupnoIzabrano { get; set; }
    }
}
