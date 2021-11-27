using Pelikula.DAO.Model;
using System.Collections.Generic;

namespace Pelikula.API.Validation
{
    public interface IFilmskaLicnostValidator : IBaseValidator<FilmskaLicnost>
    {
        void ValidateEntitiesExists(List<int> ids);
    }
}
