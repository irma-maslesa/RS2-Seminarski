using AutoMapper;
using Pelikula.API.Model;
using Pelikula.API.Model.Anketa;
using Pelikula.API.Model.Artikal;
using Pelikula.API.Model.Dojam;
using Pelikula.API.Model.Film;
using Pelikula.API.Model.FilmskaLicnost;
using Pelikula.API.Model.JedinicaMjere;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Model.Obavijest;
using Pelikula.API.Model.Prodaja;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Model.Rezervacija;
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

            CreateMap<ProjekcijaTermin, ProjekcijaTerminResponse>().ReverseMap();
            CreateMap<ProjekcijaTermin, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Termin:dd/MM/yyyy, HH:mm}"))
                .ReverseMap();
            CreateMap<ProjekcijaTerminUpsertRequest, ProjekcijaTermin>().ReverseMap();

            CreateMap<Projekcija, ProjekcijaResponse>()
                .ForMember(dest => dest.Termini,
                opts => opts.MapFrom(src => src.ProjekcijaTermin))
                .ReverseMap();
            CreateMap<Projekcija, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Film.Naslov} - {src.Sala.Naziv} ({src.VrijediOd:dd/MM/yyyy} - {src.VrijediDo:dd/MM/yyyy})"))
                .ReverseMap();
            CreateMap<ProjekcijaUpsertRequest, Projekcija>()
                .ForMember(dest => dest.ProjekcijaTermin,
                opts => opts.Ignore())
                .ReverseMap();
            CreateMap<ProjekcijaUpsertRequest, Projekcija>()
                 .ForMember(dest => dest.ProjekcijaTermin,
                 opts => opts.Ignore())
                 .ReverseMap();

            CreateMap<Dojam, DojamResponse>().ReverseMap();
            CreateMap<Dojam, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.Korisnik.KorisnickoIme} {src.Projekcija.Film.Naslov} - {src.Projekcija.Sala.Naziv} ({src.Projekcija.VrijediOd:dd/MM/yyyy}) - {src.Projekcija.VrijediDo:dd/MM/yyyy} ({src.Ocjena})"))
                .ReverseMap();
            CreateMap<DojamUpsertRequest, Dojam>().ReverseMap();

            CreateMap<SjedisteRezervacija, SjedisteRezervacijaResponse>().ReverseMap();
            CreateMap<SjedisteRezervacija, LoV>().ReverseMap();
            CreateMap<SjedisteRezervacijaUpsertRequest, SjedisteRezervacija>().ReverseMap();
            CreateMap<SjedisteRezervacijaUpsertRequest, SjedisteRezervacija>().ReverseMap();

            CreateMap<Rezervacija, RezervacijaResponse>()
                .ForMember(dest => dest.Sjedista,
                opts => opts.MapFrom(src => src.SjedisteRezervacija))
                .ReverseMap();
            CreateMap<Rezervacija, LoV>()
                .ForMember(dest => dest.Naziv,
                opts => opts.MapFrom(src => $"{src.ProjekcijaTermin.Projekcija.Film.Naslov} - {src.ProjekcijaTermin.Projekcija.Sala.Naziv} ({src.ProjekcijaTermin.Projekcija.VrijediOd:dd/MM/yyyy} - {src.ProjekcijaTermin.Projekcija.VrijediDo:dd/MM/yyyy}) - {src.Korisnik.Ime} {src.Korisnik.Prezime} ({src.Korisnik.KorisnickoIme}) - {src.BrojSjedista}"))
                .ReverseMap();
            CreateMap<RezervacijaUpsertRequest, Rezervacija>()
                .ForMember(dest => dest.SjedisteRezervacija,
                opts => opts.Ignore())
                .ReverseMap();

            CreateMap<ProdajaArtikal, ProdajaArtikalResponse>().ReverseMap();
            CreateMap<ProdajaArtikalInsertRequest, ProdajaArtikal>().ReverseMap();

            CreateMap<ProdajaRezervacija, ProdajaRezervacijaResponse>().ReverseMap();
            CreateMap<ProdajaRezervacijaInsertRequest, ProdajaRezervacija>().ReverseMap();

            CreateMap<Prodaja, ProdajaResponse>().ReverseMap();
            CreateMap<ProdajaInsertRequest, Prodaja>().ReverseMap();
        }
    }
}
