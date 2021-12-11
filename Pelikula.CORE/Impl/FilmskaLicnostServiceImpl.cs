using AutoMapper;
using Pelikula.API.Api;
using Pelikula.API.Model.FilmskaLicnost;
using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Impl
{
    public class FilmskaLicnostServiceImpl :
        CrudServiceImpl<FilmskaLicnostResponse, FilmskaLicnost, FilmskaLicnostUpsertRequest, FilmskaLicnostUpsertRequest>,
        IFilmskaLicnostService
    {
        public FilmskaLicnostServiceImpl(AppDbContext context, IMapper mapper, IFilmskaLicnostValidator validator) : base(context, mapper, validator) {
        }
    }
}
