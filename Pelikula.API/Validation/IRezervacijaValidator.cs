using Pelikula.DAO.Model;

namespace Pelikula.API.Validation
{
    public interface IRezervacijaValidator : IBaseValidator<Rezervacija>
    {
        void ValidateKorisnikTermin(int? id, int korisnikId, int projekcijaTerminId);
    }
}
