using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Projekcija;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using Pelikula.API.Model;
using System.Threading.Tasks;

namespace Pelikula.CORE.Impl
{
    public class ProjekcijaServiceImpl :
        CrudServiceImpl<ProjekcijaResponse, Projekcija, ProjekcijaInsertRequest, ProjekcijaUpdateRequest>,
        IProjekcijaService
    {
        protected new IProjekcijaValidator Validator { get; set; }
        protected IFilmValidator FilmValidator { get; set; }
        protected ISalaValidator SalaValidator { get; set; }
        protected IKorisnikValidator KorisnikValidator { get; set; }

        public ProjekcijaServiceImpl(AppDbContext context, IMapper mapper, IProjekcijaValidator validator, IFilmValidator filmValidator, ISalaValidator salaValidator, IKorisnikValidator korisnikValidator) : base(context, mapper, validator)
        {
            SalaValidator = salaValidator;
            FilmValidator = filmValidator;
            KorisnikValidator = korisnikValidator;
            Validator = validator;
        }

        public override PagedPayloadResponse<ProjekcijaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>().Include(e => e.Film).Include(e => e.Sala).Include(e => e.ProjekcijaTermin).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            List<ProjekcijaResponse> responseList = Mapper.Map<List<ProjekcijaResponse>>(entityList);

            PaginationUtility.PagedData<ProjekcijaResponse> pagedResponse = PaginationUtility.Paginaion<ProjekcijaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ProjekcijaResponse> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Projekcija entity = Context.Set<Projekcija>().Include(e => e.Film).Include(e => e.Sala).Include(e => e.ProjekcijaTermin).FirstOrDefault(e => e.Id == id);

            ProjekcijaResponse response = Mapper.Map<ProjekcijaResponse>(entity);

            return new PayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, response);
        }

        public override PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>().Include(e => e.Film).Include(e => e.Sala).Include(e => e.ProjekcijaTermin).ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

            PaginationUtility.PagedData<LoV> pagedResponse = PaginationUtility.Paginaion<LoV>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<LoV>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ProjekcijaResponse> Insert(ProjekcijaInsertRequest request)
        {
            Validator.ValidateEntityExists(request);
            SalaValidator.ValidateEntityExists(request.SalaId);
            FilmValidator.ValidateEntityExists(request.FilmId);
            Validator.ValidateTermin(request.ProjekcijaTermin);

            Projekcija entity = Mapper.Map<ProjekcijaInsertRequest, Projekcija>(request);
            entity = Context.Set<Projekcija>().Add(entity).Entity;
            Context.SaveChanges();

            if (request.ProjekcijaTermin != null)
            {
                foreach (var termin in request.ProjekcijaTermin)
                {
                    termin.ProjekcijaId = entity.Id;
                    Context.ProjekcijaTermin.Add(Mapper.Map<ProjekcijaTerminInsertRequest, ProjekcijaTermin>(termin));
                }

            }

            Context.SaveChanges();

            ProjekcijaResponse response = Mapper.Map<Projekcija, ProjekcijaResponse>(entity);

            return new PayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ProjekcijaResponse> Update(int id, ProjekcijaUpdateRequest request)
        {
            Validator.ValidateEntityExists(id, request);
            Validator.ValidateEntityExists(id);
            SalaValidator.ValidateEntityExists(request.SalaId);
            FilmValidator.ValidateEntityExists(request.FilmId);
            Validator.ValidateTermin(request.ProjekcijaTermin);

            Projekcija entity = Context.Set<Projekcija>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Projekcija>().Update(entity);
            Context.SaveChanges();

            if (request.ProjekcijaTermin != null)
            {
                foreach (var termin in request.ProjekcijaTermin)
                {
                    ProjekcijaTermin terminEntity = Context.ProjekcijaTermin.Find(termin.Id);

                    if (terminEntity != null)
                    {
                        terminEntity = Mapper.Map(termin, terminEntity);
                        Context.ProjekcijaTermin.Update(terminEntity);
                    }
                    else
                    {
                        termin.ProjekcijaId = entity.Id;
                        Context.ProjekcijaTermin.Add(Mapper.Map<ProjekcijaTerminUpdateRequest, ProjekcijaTermin>(termin));
                    }
                }
            }

            Context.SaveChanges();

            ProjekcijaResponse response = Mapper.Map<Projekcija, ProjekcijaResponse>(entity);

            return new PayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, response);
        }

        public PagedPayloadResponse<ProjekcijaResponse> GetActive(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter, IEnumerable<SortingUtility.SortingParams> sorting)
        {
            var datum = DateTime.Now.Date;

            IEnumerable<Projekcija> entityList = Context.Set<Projekcija>()
                .Include(e => e.Film)
                .Include(e => e.Sala)
                .Include(e => e.ProjekcijaTermin)
                .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo >= datum)
                .ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Projekcija>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Projekcija>.SortData(sorting, entityList) : entityList;

            List<ProjekcijaResponse> responseList = Mapper.Map<List<ProjekcijaResponse>>(entityList);

            PaginationUtility.PagedData<ProjekcijaResponse> pagedResponse = PaginationUtility.Paginaion<ProjekcijaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public async Task<ListPayloadResponse<ProjekcijaResponse>> GetPreporucene(string korisnickoIme)
        {
            var datum = DateTime.Now.Date;

            var preporuceneProjekcije = new List<Projekcija>();
            var maksimalnoPreporucenih = 5;

            var korisnik = await Context.Korisnik.FirstOrDefaultAsync(x => x.KorisnickoIme.ToLower().Equals(korisnickoIme.ToLower()));
            if (korisnik != null)
            {
                var preporuceniRediteljiIds = new List<int>();
                var preporuceniZanroviIds = new List<int>();
                var preporuceneProjekcijeIds = new List<int>();

                var posjeceneProjekcije = await Context.ProjekcijaKorisnik
                                                        .Include(e => e.Projekcija)
                                                        .ThenInclude(e => e.Film)
                                                        .Where(e => e.KorisnikId == korisnik.Id)
                                                        .Select(e => e.Projekcija).ToListAsync();

                preporuceniRediteljiIds.AddRange(posjeceneProjekcije.Where(e => e.Film.RediteljId != null)
                                                                    .Select(e => e.Film.RediteljId.Value));
                preporuceniZanroviIds.AddRange(posjeceneProjekcije.Where(e => e.Film.ZanrId != null)
                                                                    .Select(e => e.Film.ZanrId.Value));

                preporuceneProjekcijeIds.AddRange(posjeceneProjekcije.Select(e => e.Id));

                if (preporuceniRediteljiIds.Any() || preporuceniZanroviIds.Any())
                {
                    if (preporuceniRediteljiIds.Any() && preporuceniZanroviIds.Any())
                    {
                        preporuceneProjekcije = await Context.Projekcija
                                                        .Include(e => e.ProjekcijaTermin)
                                                        .Include(e => e.Film)
                                                        .Include(e => e.Sala)
                                                        .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo.Date >= datum &&
                                                                    !preporuceneProjekcijeIds.Contains(e.Id) &&
                                                                    ((e.Film.RediteljId != null && preporuceniRediteljiIds.Contains(e.Film.RediteljId.Value)) ||
                                                                    (e.Film.ZanrId != null && preporuceniZanroviIds.Contains(e.Film.ZanrId.Value))))
                                                        .OrderBy(e => Guid.NewGuid()).Take(maksimalnoPreporucenih)
                                                        .ToListAsync();
                    }
                    else if (preporuceniRediteljiIds.Any())
                    {
                        preporuceneProjekcije = await Context.Projekcija
                                                        .Include(e => e.ProjekcijaTermin)
                                                        .Include(e => e.Film)
                                                        .Include(e => e.Sala)
                                                        .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo.Date >= datum &&
                                                                    !preporuceneProjekcijeIds.Contains(e.Id) &&
                                                                    e.Film.RediteljId != null && preporuceniRediteljiIds.Contains(e.Film.RediteljId.Value))
                                                        .OrderBy(e => Guid.NewGuid()).Take(maksimalnoPreporucenih)
                                                        .ToListAsync();
                    }
                    else
                    {
                        preporuceneProjekcije = await Context.Projekcija
                                                        .Include(e => e.ProjekcijaTermin)
                                                        .Include(e => e.Film)
                                                        .Include(e => e.Sala)
                                                        .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo.Date >= datum &&
                                                                    !preporuceneProjekcijeIds.Contains(e.Id) &&
                                                                    e.Film.ZanrId != null && preporuceniZanroviIds.Contains(e.Film.ZanrId.Value))
                                                        .OrderBy(e => Guid.NewGuid()).Take(maksimalnoPreporucenih)
                                                        .ToListAsync();
                    }
                }
            }

            if (!preporuceneProjekcije.Any())
                preporuceneProjekcije = await Context.Projekcija
                            .Include(e => e.ProjekcijaTermin)
                            .Include(e => e.Film)
                            .Include(e => e.Sala)
                            .Where(e => e.VrijediOd.Date <= datum && e.VrijediDo.Date >= datum)
                            .OrderBy(e => Guid.NewGuid()).Take(maksimalnoPreporucenih)
                            .ToListAsync();


            var preporuceneProjekcijeResponse = Mapper.Map<List<ProjekcijaResponse>>(preporuceneProjekcije);
            return new ListPayloadResponse<ProjekcijaResponse>(HttpStatusCode.OK, preporuceneProjekcijeResponse);
        }

        public PayloadResponse<string> PosjetiProjekciju(int projekcijaId, int korisnikId)
        {
            Validator.ValidateEntityExists(projekcijaId);
            KorisnikValidator.ValidateEntityExists(korisnikId);

            var datum = DateTime.Now;

            var projekcijaKorisnik = Context.ProjekcijaKorisnik
                .FirstOrDefault(x => x.ProjekcijaId == projekcijaId && x.KorisnikId == korisnikId);

            if (projekcijaKorisnik == null)
            {
                projekcijaKorisnik = new ProjekcijaKorisnik()
                {
                    DatumPosjete = datum,
                    KorisnikId = korisnikId,
                    ProjekcijaId = projekcijaId
                };

                Context.Add(projekcijaKorisnik);
            }


            projekcijaKorisnik.DatumPosljednjePosjete = datum;
            Context.SaveChanges();

            return new PayloadResponse<string>(HttpStatusCode.OK, "Posjeta uspješno dodana!");
        }
    }
}
