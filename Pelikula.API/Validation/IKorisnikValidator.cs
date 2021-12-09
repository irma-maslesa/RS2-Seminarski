using Pelikula.API.Model;
using Pelikula.DAO.Model;

namespace Pelikula.API.Validation
{
    public interface IKorisnikValidator : IBaseValidator<Korisnik>
    {
        void ValidateKorisnickoIme(string korisnickoIme, int? id = null);
        void ValidateEmail(string email, int? id= null);

        void ValidateTipKorisnika(int id, KorisnikTip tipKorisnika);
    }
}
