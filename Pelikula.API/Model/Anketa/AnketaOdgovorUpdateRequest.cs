namespace Pelikula.API.Model.Anketa
{
    public partial class AnketaOdgovorUpdateRequest
    {
        public int Id { get; set; }
        public string Odgovor { get; set; }
        public int RedniBroj { get; set; }

        public int AnketaId { get; set; }
    }
}
