using System;
using System.Collections.Generic;

namespace Pelikula.API.Model.Projekcija
{
    public class ProjekcijaResponse
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum { get; set; }
        public DateTime VrijediOd { get; set; }
        public DateTime VrijediDo { get; set; }

        public LoV Film { get; set; }
        public LoV Sala { get; set; }
        public ICollection<LoV> Termini { get; set; }

        public override string ToString()
        {
            return $"{Film?.Naziv} - {Sala?.Naziv} ({VrijediOd:dd/MM/yyyy} - {VrijediDo:dd/MM/yyyy})";
        }
    }
}
