using AutoMapper;
using Pelikula.API.Model;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.JedinicaMjere;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.Obavijest;
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

            CreateMap<Korisnik, KorisnikResponse>()
                .ForMember(dest => dest.Slika,
                opts => opts.MapFrom(src => src.Slika == null || src.Slika.Length == 0 ? null : src.Slika))
                .ForMember(dest => dest.SlikaThumb,
                opts => opts.MapFrom(src => src.SlikaThumb == null || src.SlikaThumb.Length == 0 ? null : src.SlikaThumb))
                .ReverseMap();
            CreateMap<Korisnik, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Ime} {src.Prezime} ({src.KorisnickoIme})"))
                .ReverseMap();
            CreateMap<KorisnikUpsertRequest, Korisnik>().ReverseMap();


            CreateMap<JedinicaMjere, JedinicaMjereResponse>().ReverseMap();
            CreateMap<JedinicaMjere, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => src.KratkiNaziv)).ReverseMap();
            CreateMap<JedinicaMjereUpsertRequest, JedinicaMjere>().ReverseMap();

            CreateMap<Obavijest, ObavijestResponse>()
                .ReverseMap();
            CreateMap<Obavijest, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Naslov} ({src.Datum:dd/MM/YYY})"))
                .ReverseMap();
            CreateMap<ObavijestUpsertRequest, Obavijest>().ReverseMap();

            CreateMap<Anketa, AnketaResponse>()
                /*.ForMember(dest => dest.Odgovori, 
                opts => opts.MapFrom(src => src.AnketaOdgovor))*/
                .ReverseMap();
            CreateMap<Anketa, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Naslov} ({src.Datum:dd/MM/YYY})"))
                .ReverseMap();
            CreateMap<AnketaInsertRequest, Anketa>()
                /*.ForMember(dest => dest.AnketaOdgovor,
                opts => opts.Ignore())*/
                .ReverseMap(); 
            CreateMap<AnketaUpdateRequest, Anketa>()
                 /*.ForMember(dest => dest.AnketaOdgovor,
                 opts => opts.Ignore())*/
                 .ReverseMap();

            CreateMap<AnketaOdgovor, AnketaOdgovorResponse>()
                .ReverseMap();
            CreateMap<AnketaOdgovor, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.RedniBroj}. {src.Odgovor}"))
                .ReverseMap();
            CreateMap<AnketaOdgovorInsertRequest, AnketaOdgovor>()
                .ReverseMap(); 
            CreateMap<AnketaOdgovorUpdateRequest, AnketaOdgovor>()
                 .ReverseMap();
        }
    }
}
