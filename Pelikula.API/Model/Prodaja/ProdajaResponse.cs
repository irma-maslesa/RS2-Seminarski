using Pelikula.API.Model.Rezervacija;
using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaResponse
    {
        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public DateTime Datum { get; set; }

        public decimal UkupnaCijena { get; set; }

        public LoV Korisnik { get; set; }
        public ICollection<ProdajaArtikalResponse> ProdajaArtikal { get; set; }
        public RezervacijaResponse Rezervacija { get; set; }
    }
}
