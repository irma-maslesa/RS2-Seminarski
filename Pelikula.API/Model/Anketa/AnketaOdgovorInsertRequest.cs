namespace Pelikula.API.Model.Anketa
{
    public class AnketaOdgovorInsertRequest
    {
        public string Odgovor { get; set; }
        public int RedniBroj { get; set; }

        public int AnketaId { get; set; }
    }
}
