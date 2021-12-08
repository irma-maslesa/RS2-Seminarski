using System.Collections.Generic;
using System.Linq;

namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaExtendedResponse : ProdajaResponse
    {
        public decimal UkupnaCijena { get; set; }
        public LoV Film { get; set; }
        public LoV Sala { get; set; }

        public ProdajaExtendedResponse(ProdajaResponse prodaja, bool saKolekcijama)
        {
            Id = prodaja.Id;
            BrojRacuna = prodaja.BrojRacuna;
            Korisnik = prodaja.Korisnik;
            Datum = prodaja.Datum;
            Popust = prodaja.Popust;
            Porez = prodaja.Porez;
            UkupnaCijena = GetUkupnaCijena(prodaja.ProdajaArtikal, prodaja.ProdajaRezervacija);

            if (saKolekcijama)
            {
                if (prodaja.ProdajaRezervacija.Any())
                {
                    var rezervacija = prodaja.ProdajaRezervacija.First().Rezervacija;
                    Film = rezervacija.ProjekcijaTermin.Projekcija.Film;
                    Sala = rezervacija.ProjekcijaTermin.Projekcija.Sala;
                }

                ProdajaArtikal = prodaja.ProdajaArtikal;
                ProdajaRezervacija = prodaja.ProdajaRezervacija;
            }
        }

        private decimal GetUkupnaCijena(ICollection<ProdajaArtikalResponse> prodajaArtikal, ICollection<ProdajaRezervacijaResponse> prodajaRezervacija)
        {
            decimal ukupnaCijena = 0;

            foreach (var artikal in prodajaArtikal)
                ukupnaCijena += (artikal.Cijena * artikal.Kolicina);

            foreach (var rezervacija in prodajaRezervacija)
                ukupnaCijena += rezervacija.Cijena;

            return ukupnaCijena;
        }
    }
}
