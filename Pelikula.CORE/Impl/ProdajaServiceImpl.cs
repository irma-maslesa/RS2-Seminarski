using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Prodaja;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Pelikula.CORE.Filter;
using Pelikula.API.Model.Rezervacija;
using System;
using Pelikula.API.Model;

namespace Pelikula.CORE.Impl
{
    public class ProdajaServiceImpl :
        CrudServiceImpl<ProdajaResponse, Prodaja, ProdajaInsertRequest, object>,
        IProdajaService
    {
        protected IKorisnikValidator KorisnikValidator { get; set; }
        protected IRezervacijaValidator RezervacijaValidator { get; set; }
        protected IArtikalValidator ArtikalValidator { get; set; }

        public ProdajaServiceImpl(AppDbContext context, IMapper mapper, IProdajaValidator validator, IKorisnikValidator korisnikValidator, IRezervacijaValidator rezervacijaValidator, IArtikalValidator artikalValidator) : base(context, mapper, validator)
        {
            KorisnikValidator = korisnikValidator;
            RezervacijaValidator = rezervacijaValidator;
            ArtikalValidator = artikalValidator;
        }

        public override PagedPayloadResponse<ProdajaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Prodaja> entityList = Context.Set<Prodaja>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProdajaArtikal)
                    .ThenInclude(e => e.Artikal)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.SjedisteRezervacija)
                    .ThenInclude(e => e.Sjediste)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.ProjekcijaTermin)
                    .ThenInclude(e => e.Projekcija)
                    .ThenInclude(e => e.Film)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.ProjekcijaTermin)
                    .ThenInclude(e => e.Projekcija)
                    .ThenInclude(e => e.Sala)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.Korisnik)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Prodaja>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Prodaja>.SortData(sorting, entityList) : entityList;

            List<ProdajaResponse> responseList = Mapper.Map<List<ProdajaResponse>>(entityList);
            responseList.ForEach(e => e.UkupnaCijena = GetUkupnaCijena(e.ProdajaArtikal, e.Rezervacija, e.Porez, e.Popust));

            PaginationUtility.PagedData<ProdajaResponse> pagedResponse = PaginationUtility.Paginaion<ProdajaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProdajaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ProdajaResponse> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Prodaja entity = Context.Set<Prodaja>()
                .Include(e => e.Korisnik)
                .Include(e => e.ProdajaArtikal)
                    .ThenInclude(e => e.Artikal)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.SjedisteRezervacija)
                    .ThenInclude(e => e.Sjediste)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.ProjekcijaTermin)
                    .ThenInclude(e => e.Projekcija)
                    .ThenInclude(e => e.Film)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.ProjekcijaTermin)
                    .ThenInclude(e => e.Projekcija)
                    .ThenInclude(e => e.Sala)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.Korisnik)
                .FirstOrDefault(e => e.Id == id);

            ProdajaResponse response = Mapper.Map<ProdajaResponse>(entity);
            response.UkupnaCijena = GetUkupnaCijena(response.ProdajaArtikal, response.Rezervacija, response.Porez, response.Popust);

            return new PayloadResponse<ProdajaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ProdajaResponse> Insert(ProdajaInsertRequest request)
        {
            KorisnikValidator.ValidateEntityExists(request.KorisnikId);
            KorisnikValidator.ValidateTipKorisnika(request.KorisnikId, KorisnikTip.Radnik);
            if (request.RezervacijaId.HasValue)
            {
                RezervacijaValidator.ValidateEntityExists(request.RezervacijaId.Value);
                RezervacijaValidator.ValidateEntityProdano(request.RezervacijaId.Value);
                RezervacijaValidator.ValidateEntityOtkazano(request.RezervacijaId.Value);
            }
            if (request.ProdajaArtikal != null)
                ArtikalValidator.ValidateEntitiesExists(request.ProdajaArtikal.Select(e => e.ArtikalId).ToList());

            Prodaja entity = Mapper.Map<ProdajaInsertRequest, Prodaja>(request);
            entity.Datum = DateTime.Now;
            entity.BrojRacuna = GenerateBrojRacuna(entity.Datum);

            entity = Context.Prodaja.Add(entity).Entity;

            Context.SaveChanges();

            if (request.RezervacijaId.HasValue)
            {
                Rezervacija rezervacija = Context.Rezervacija.Find(request.RezervacijaId.Value);
                rezervacija.DatumProdano = entity.Datum;

                Context.Rezervacija.Update(rezervacija);
                Context.SaveChanges();
            }

            if (request.ProdajaArtikal != null)
            {
                foreach (var prodajaArtikal in request.ProdajaArtikal)
                {
                    ProdajaArtikal prodajaArtikalEntity = Mapper.Map<ProdajaArtikal>(prodajaArtikal);
                    prodajaArtikalEntity.ProdajaId = entity.Id;

                    Context.ProdajaArtikal.Add(prodajaArtikalEntity);
                }
            }

            Context.SaveChanges();

            ProdajaResponse response = Mapper.Map<Prodaja, ProdajaResponse>(entity);
            response.UkupnaCijena = GetUkupnaCijena(response.ProdajaArtikal, response.Rezervacija, response.Porez, response.Popust);

            return new PayloadResponse<ProdajaResponse>(HttpStatusCode.OK, response);
        }

        private string GenerateBrojRacuna(DateTime datum)
        {
            var guid = Guid.NewGuid().ToString();

            var godina = datum.Year.ToString();
            var mjesec = datum.Month.ToString();
            var dan = datum.Day.ToString();
            var sat = datum.Hour.ToString();
            var minuta = datum.Minute.ToString();
            var sekunda = datum.Second.ToString();

            string brojRacuna = dan + mjesec + godina + guid + sekunda + minuta + sat;

            if (Context.Prodaja.FirstOrDefault(e => e.BrojRacuna == brojRacuna) != null)
                return GenerateBrojRacuna(datum);
            else
                return brojRacuna;
        }

        public override PayloadResponse<ProdajaResponse> Update(int id, object request)
        {
            throw new UserException("Update prodaje nije moguć!", HttpStatusCode.NotFound);
        }

        private decimal GetUkupnaCijena(ICollection<ProdajaArtikalResponse> prodajaArtikli, RezervacijaResponse rezervacija, decimal porez, decimal popust)
        {
            decimal ukupnaCijena = 0;

            foreach (var prodajaArtikal in prodajaArtikli)
                ukupnaCijena += (prodajaArtikal.Artikal.Cijena * prodajaArtikal.Kolicina);

            if (rezervacija != null)
                ukupnaCijena += rezervacija.Cijena;

            ukupnaCijena *= 1 + porez;
            ukupnaCijena *= 1 - popust;

            return Math.Round(ukupnaCijena, 2);
        }
    }
}
