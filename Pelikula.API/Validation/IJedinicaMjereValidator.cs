using Pelikula.API.Model.JedinicaMjere;
using Pelikula.DAO.Model;

namespace Pelikula.API.Validation
{
    public interface IJedinicaMjereValidator : IBaseValidator<JedinicaMjere>
    {
        void ValidateUpsertRequest(JedinicaMjereUpsertRequest request, int? id = null);
    }
}
