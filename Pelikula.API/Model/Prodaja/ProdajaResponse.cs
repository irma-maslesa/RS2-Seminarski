using Pelikula.API.Model.Korisnik;
using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaResponse
    {
        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public DateTime Datum { get; set; }
        public decimal Popust { get; set; }
        public decimal Porez { get; set; }

        public KorisnikResponse Korisnik { get; set; }
        public ICollection<ProdajaArtikalResponse> ProdajaArtikal { get; set; }
        public ICollection<ProdajaRezervacijaResponse> ProdajaRezervacija { get; set; }
    }
}
