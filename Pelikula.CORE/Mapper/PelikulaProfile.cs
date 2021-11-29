using AutoMapper;
using Pelikula.API.Model;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Artikal;
using Pelikula.API.Model.Film;
using Pelikula.API.Model.FilmskaLicnost;
using Pelikula.API.Model.JedinicaMjere;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.Obavijest;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Sala;
using Pelikula.API.Model.TipKorisnika;
using Pelikula.API.Model.Zanr;
using Pelikula.DAO.Model;

namespace FudbalskaLigaBiH.CORE.Mapper
{
    public class PelikulaProfile : Profile
    {
        public PelikulaProfile()
        {
            AllowNullCollections = true;

            CreateMap<Zanr, ZanrResponse>().ReverseMap();
            CreateMap<Zanr, LoV>().ReverseMap();
            CreateMap<ZanrUpsertRequest, Zanr>().ReverseMap();

            CreateMap<TipKorisnika, TipKorisnikaResponse>().ReverseMap();
            CreateMap<TipKorisnika, LoV>().ReverseMap();
            CreateMap<TipKorisnikaUpsertRequest, TipKorisnika>().ReverseMap();

            CreateMap<Korisnik, KorisnikResponse>().ReverseMap();
            CreateMap<Korisnik, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Ime} {src.Prezime} ({src.KorisnickoIme})"))
                .ReverseMap();
            CreateMap<KorisnikUpsertRequest, Korisnik>().ReverseMap();
            CreateMap<KorisnikRegistracijaRequest, Korisnik>().ReverseMap();


            CreateMap<JedinicaMjere, JedinicaMjereResponse>().ReverseMap();
            CreateMap<JedinicaMjere, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => src.KratkiNaziv)).ReverseMap();
            CreateMap<JedinicaMjereUpsertRequest, JedinicaMjere>().ReverseMap();

            CreateMap<Obavijest, ObavijestResponse>().ReverseMap();
            CreateMap<Obavijest, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Naslov} ({src.Datum:dd/MM/yyyy})"))
                .ReverseMap();
            CreateMap<ObavijestUpsertRequest, Obavijest>().ReverseMap();

            CreateMap<Anketa, AnketaResponse>()
                .ForMember(dest => dest.Odgovori,
                opts => opts.MapFrom(src => src.AnketaOdgovor))
                .ReverseMap();
            CreateMap<Anketa, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Naslov} ({src.Datum:dd/MM/yyyy})"))
                .ReverseMap();
            CreateMap<AnketaInsertRequest, Anketa>()
                .ForMember(dest => dest.AnketaOdgovor,
                opts => opts.Ignore())
                .ReverseMap();
            CreateMap<AnketaUpdateRequest, Anketa>()
                 .ForMember(dest => dest.AnketaOdgovor,
                 opts => opts.Ignore())
                 .ReverseMap();

            CreateMap<AnketaOdgovor, AnketaOdgovorResponse>().ReverseMap();
            CreateMap<AnketaOdgovor, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.RedniBroj}. {src.Odgovor}"))
                .ReverseMap();
            CreateMap<AnketaOdgovorInsertRequest, AnketaOdgovor>().ReverseMap();
            CreateMap<AnketaOdgovorUpdateRequest, AnketaOdgovor>().ReverseMap();

            CreateMap<AnketaOdgovorKorisnikInsertRequest, AnketaOdgovorKorisnik>()
                .ReverseMap();

            CreateMap<Artikal, ArtikalResponse>().ReverseMap();
            CreateMap<Artikal, LoV>().ReverseMap();
            CreateMap<ArtikalUpsertRequest, Artikal>().ReverseMap();

            CreateMap<FilmskaLicnost, FilmskaLicnostResponse>().ReverseMap();
            CreateMap<FilmskaLicnost, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Ime} {src.Prezime}"))
                .ReverseMap();
            CreateMap<FilmskaLicnostUpsertRequest, FilmskaLicnost>().ReverseMap();

            CreateMap<FilmGlumac, FilmGlumacResponse>().ReverseMap();

            CreateMap<Film, FilmResponse>()
                .ForMember(dest => dest.Glumci,
                opts => opts.MapFrom(src => src.FilmGlumac))
                .ReverseMap();
            CreateMap<Film, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => src.Naslov))
                .ReverseMap();
            CreateMap<FilmUpsertRequest, Film>()
                .ForMember(dest => dest.FilmGlumac,
                opts => opts.Ignore())
                .ReverseMap();

            CreateMap<Sjediste, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Red}{src.Broj}"))
                .ReverseMap();

            CreateMap<Sala, SalaResponse>().ReverseMap();
            CreateMap<Sala, LoV>().ReverseMap();
            CreateMap<SalaUpsertRequest, Sala>().ReverseMap();

            CreateMap<ProjekcijaTermin, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => src.Termin))
                .ReverseMap();
            CreateMap<ProjekcijaTerminInsertRequest, ProjekcijaTermin>().ReverseMap();
            CreateMap<ProjekcijaTerminUpdateRequest, ProjekcijaTermin>().ReverseMap();

            CreateMap<Projekcija, ProjekcijaResponse>()
                .ForMember(dest => dest.Termini,
                opts => opts.MapFrom(src => src.ProjekcijaTermin))
                .ReverseMap();
            CreateMap<Projekcija, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Film.Naslov} - {src.Sala.Naziv} ({src.VrijediOd:dd/MM/yyyy} - {src.VrijediDo:dd/MM/yyyy})"))
                .ReverseMap();
            CreateMap<ProjekcijaInsertRequest, Projekcija>()
                .ForMember(dest => dest.ProjekcijaTermin,
                opts => opts.Ignore())
                .ReverseMap();
            CreateMap<ProjekcijaUpdateRequest, Projekcija>()
                 .ForMember(dest => dest.ProjekcijaTermin,
                 opts => opts.Ignore())
                 .ReverseMap();
        }
    }
}
