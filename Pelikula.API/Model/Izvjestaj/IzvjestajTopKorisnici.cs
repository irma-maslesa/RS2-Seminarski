namespace Pelikula.API.Model.Izvjestaj
{
    public class IzvjestajTopKorisnici
    {
        public string Korisnik { get; set; }
        public int BrojKupovina { get; set; }

        public int BrojKarti { get; set; }

        public decimal UkupnaCijena { get; set; }
    }
}
