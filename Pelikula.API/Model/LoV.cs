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

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var lov = (LoV)obj;
                return Id == lov.Id && Naziv == lov.Naziv;
            }
        }
    }
}
