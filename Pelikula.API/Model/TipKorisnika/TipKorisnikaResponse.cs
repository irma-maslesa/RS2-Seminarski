namespace Pelikula.API.Model.TipKorisnika
{
    public class TipKorisnikaResponse
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public override string ToString() {
            return Naziv;
        }
    }
}
