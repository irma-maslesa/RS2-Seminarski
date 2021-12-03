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
    public class SalaValidatorImpl : BaseValidatorImpl<Sala>, ISalaValidator
    {
        public SalaValidatorImpl(AppDbContext context) : base(context)
        {
        }

        public void ValidateSjedistaExist(ICollection<int> sjedistaIds)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var sjedisteId in sjedistaIds)
                if (!Context.Sjediste.Any(e => e.Id == sjedisteId))
                    sb.Append($"Sjediste({sjedisteId}) ne postoji! ");

            if (sb.ToString().Length != 0)
                throw new UserException(sb.ToString(), HttpStatusCode.BadRequest);
        }
    }
}
