using Pelikula.DAO.Model;

namespace Pelikula.API.Validation
{
    public interface IDojamValidator : IBaseValidator<Dojam>
    {
        void ValidateComboDoesNotExist(int? id, int korisnikId, int projekcijaId);
    }
}
