namespace Pelikula.API.Model.Anketa
{
    public class AnketaExtendedResponse : AnketaResponse
    {
        public AnketaOdgovorResponse KorisnikAnketaOdgovor { get; set; }

        public AnketaExtendedResponse() {

        }

        public AnketaExtendedResponse(AnketaResponse anketa) {
            Id = anketa.Id;
            Naslov = anketa.Naslov;
            Datum = anketa.Datum;
            ZakljucenoDatum = anketa.ZakljucenoDatum;

            Korisnik = anketa.Korisnik;
            Odgovori = anketa.Odgovori;
        }
    }
}
