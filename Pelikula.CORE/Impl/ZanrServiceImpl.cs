using AutoMapper;
using Pelikula.API.Api;
using Pelikula.API.Model.Zanr;
using Pelikula.API.Validation;
using Pelikula.DAO;
using Pelikula.DAO.Model;

namespace Pelikula.CORE.Impl
{
    public class ZanrServiceImpl :
        CrudServiceImpl<ZanrResponse, Zanr, ZanrUpsertRequest, ZanrUpsertRequest>,
        IZanrService
    {
        public ZanrServiceImpl(AppDbContext context, IMapper mapper, IZanrValidator validator) : base(context, mapper, validator) {
        }
    }
}
