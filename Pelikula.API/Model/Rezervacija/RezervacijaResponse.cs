using Pelikula.API.Model.Projekcija;
using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Rezervacija
{
    public class RezervacijaResponse
    {
        public int Id { get; set; }
        public int BrojSjedista { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumProjekcije { get; set; }
        public DateTime? DatumProdano { get; set; }
        public DateTime? DatumOtkazano { get; set; }

        public LoV Korisnik { get; set; }
        public ProjekcijaTerminResponse ProjekcijaTermin { get; set; }
        public ICollection<SjedisteRezervacijaResponse> Sjedista { get; set; }
    }
}
