using System;

namespace Pelikula.API.Model.Projekcija
{
    public partial class ProjekcijaTerminResponse
    {
        public int Id { get; set; }
        public DateTime? Termin { get; set; }

        public ProjekcijaResponse Projekcija { get; set; }

        public override string ToString() {
            return $"{Projekcija} - {Termin.GetValueOrDefault(): dd/MM/yyyy, HH:mm}";
        }
    }
}
