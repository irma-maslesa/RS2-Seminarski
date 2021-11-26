namespace Pelikula.API.Model
{
    public class LoV
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
