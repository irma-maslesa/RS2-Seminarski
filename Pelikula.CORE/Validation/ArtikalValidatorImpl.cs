using Pelikula.API.Model.Artikal;
using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Validation
{
    public class ArtikalValidatorImpl : BaseValidatorImpl<Artikal>, IArtikalValidator
    {
        public ArtikalValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateEntitiesExists(List<int> ids)
        {
            StringBuilder sb = new StringBuilder();

            Artikal entity;

            foreach (var id in ids)
            {
                entity = Context.Artikal.Find(id);


                if (entity == null)
                    sb.Append($"Artikal({id}) ne postoji! ");
            }

            if(sb.ToString().Length != 0)
                throw new UserException(sb.ToString(), HttpStatusCode.BadRequest);

        }
    }
}
