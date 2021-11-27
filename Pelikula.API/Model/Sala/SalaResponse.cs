using System.Collections.Generic;

namespace Pelikula.API.Model.Sala
{
    public partial class SalaResponse
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int BrojSjedista { get; set; }
        public int BrojSjedistaDuzina { get; set; }
        public int BrojSjedistaSirina { get; set; }

        public List<LoV> Sjediste { get; set; }
    }
}
