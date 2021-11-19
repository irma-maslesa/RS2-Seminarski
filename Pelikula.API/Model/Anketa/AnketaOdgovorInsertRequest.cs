namespace Pelikula.API.Model.Anketa
{
    public partial class AnketaOdgovorInsertRequest
    {
        public string Odgovor { get; set; }
        public int RedniBroj { get; set; }

        public int AnketaId { get; set; }
    }
}
