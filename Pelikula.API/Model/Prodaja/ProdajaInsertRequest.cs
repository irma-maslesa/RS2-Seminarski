using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Prodaja
{
    public class ProdajaInsertRequest
    {
        public int? KorisnikId { get; set; }
        public int? RezervacijaId { get; set; }
        public DateTime? Datum { get; set; }

        public ICollection<ProdajaArtikalInsertRequest> ProdajaArtikal { get; set; }
    }
}
