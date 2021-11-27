namespace Pelikula.API.Model.Sala
{
    public partial class SalaUpsertRequest
    {
        public string Naziv { get; set; }

        public int BrojSjedistaDuzina { get; set; }
        public int BrojSjedistaSirina { get; set; }
    }
}
