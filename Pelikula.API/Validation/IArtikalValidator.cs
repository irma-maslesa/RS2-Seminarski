using Pelikula.DAO.Model;
using System.Collections.Generic;

namespace Pelikula.API.Validation
{
    public interface IArtikalValidator : IBaseValidator<Artikal>
    {
        void ValidateEntitiesExists(List<int> ids);
    }
}
