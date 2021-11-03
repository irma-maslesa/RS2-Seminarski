using AutoMapper;
using Pelikula.API.Model.Zanr;
using Pelikula.DAO.Model;

namespace FudbalskaLigaBiH.CORE.Mapper
{
    public class PelikulaProfile : Profile
    {
        public PelikulaProfile()
        {
            CreateMap<Zanr, ZanrResponse>().ReverseMap();
            CreateMap<ZanrUpsertRequest, Zanr>().ReverseMap();
        }
    }
}
