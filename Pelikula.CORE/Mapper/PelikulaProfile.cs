using AutoMapper;
using Pelikula.API.Model;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.TipKorisnika;
using Pelikula.API.Model.Zanr;
using Pelikula.DAO.Model;

namespace FudbalskaLigaBiH.CORE.Mapper
{
    public class PelikulaProfile : Profile
    {
        public PelikulaProfile()
        {
            CreateMap<Zanr, ZanrResponse>().ReverseMap();
            CreateMap<Zanr, LoV>().ReverseMap();
            CreateMap<ZanrUpsertRequest, Zanr>().ReverseMap();

            CreateMap<TipKorisnika, TipKorisnikaResponse>().ReverseMap();
            CreateMap<TipKorisnika, LoV>().ReverseMap();
            CreateMap<TipKorisnikaUpsertRequest, TipKorisnika>().ReverseMap();

            CreateMap<Korisnik, KorisnikResponse>().ReverseMap();
            CreateMap<Korisnik, LoV>()
                .ForMember(dest=> dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Ime} {src.Prezime} ({src.KorisnickoIme})"))
                .ReverseMap();
            CreateMap<KorisnikUpsertRequest, Korisnik>().ReverseMap();
        }
    }
}
