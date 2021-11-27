using Pelikula.API.Api;
using Pelikula.API.Model.FilmskaLicnost;

namespace API.Controllers
{
    public class FilmskaLicnostController :
        CrudController<FilmskaLicnostResponse, FilmskaLicnostUpsertRequest, FilmskaLicnostUpsertRequest>
    {

        public FilmskaLicnostController(IFilmskaLicnostService service) : base(service)
        {
        }
    }
}
