using Pelikula.API.Model.FilmskaLicnost;

namespace Pelikula.API.Api
{
    public interface IFilmskaLicnostService : ICrudService<FilmskaLicnostResponse, FilmskaLicnostUpsertRequest, FilmskaLicnostUpsertRequest>
    {
    }
}
