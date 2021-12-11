using Pelikula.API.Validation;
using Pelikula.CORE.Filter;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Pelikula.CORE.Validation
{
    public class FilmskaLicnostValidatorImpl : BaseValidatorImpl<FilmskaLicnost>, IFilmskaLicnostValidator
    {
        public FilmskaLicnostValidatorImpl(AppDbContext context) : base(context) {
        }

        public void ValidateEntitiesExists(List<int> ids) {
            StringBuilder sb = new StringBuilder();

            foreach (var id in ids) {
                FilmskaLicnost entity = Context.Set<FilmskaLicnost>().Find(id);

                if (entity == null)
                    sb.Append($"Glumac({id}) ne postoji! ");
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
                throw new UserException(sb.ToString(), HttpStatusCode.BadRequest);
        }
    }
}
