namespace Pelikula.API.Model.JedinicaMjere
{
    public partial class JedinicaMjereResponse
    {

        public int Id { get; set; }
        public string KratkiNaziv { get; set; }
        public string Naziv { get; set; }

        public override string ToString() {
            return KratkiNaziv;
        }
    }
}
