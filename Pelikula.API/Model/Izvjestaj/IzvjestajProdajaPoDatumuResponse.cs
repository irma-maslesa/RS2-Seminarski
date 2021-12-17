using System;
using System.Collections.Generic;
using System.Text;

namespace Pelikula.API.Model.Izvjestaj
{
    public class IzvjestajProdajaPoDatumuResponse
    {
        public string BrojRacuna { get; set; }

        public string Korisnik { get; set; }

        public string Datum { get; set; }

        public decimal UkupnaCijena { get; set; }
    }
}
