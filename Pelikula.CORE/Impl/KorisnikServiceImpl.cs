using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Korisnik;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class KorisnikServiceImpl :
        CrudServiceImpl<KorisnikResponse, Korisnik, KorisnikUpsertRequest, KorisnikUpsertRequest>,
        IKorisnikService
    {
        protected ITipKorisnikaValidator TipKorisnikaValidator { get; set; }
        public KorisnikServiceImpl(AppDbContext context, IMapper mapper, IKorisnikValidator validator, ITipKorisnikaValidator tipKorisnikaValidator) : base(context, mapper, validator)
        {
            TipKorisnikaValidator = tipKorisnikaValidator;
        }

        public override PagedPayloadResponse<KorisnikResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Korisnik> KorisnikList = Context.Set<Korisnik>().Include(e => e.TipKorisnika).ToList();

            KorisnikList = filter != null && filter.Any() ? FilterUtility.Filter<Korisnik>.FilteredData(filter, KorisnikList) : KorisnikList;
            KorisnikList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Korisnik>.SortData(sorting, KorisnikList) : KorisnikList;

            List<KorisnikResponse> responseList = Mapper.Map<List<KorisnikResponse>>(KorisnikList);

            responseList.ForEach(e => { e.Slika = e.Slika?.Length == 0 ? null : e.Slika; e.SlikaThumb = e.SlikaThumb?.Length == 0 ? null : e.SlikaThumb; });
            PaginationUtility.PagedData<KorisnikResponse> pagedResponse = PaginationUtility.Paginaion<KorisnikResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<KorisnikResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<KorisnikResponse> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Korisnik entity = Context.Set<Korisnik>().Include(e => e.TipKorisnika).Where(e => e.Id == id).SingleOrDefault();

            KorisnikResponse response = Mapper.Map<KorisnikResponse>(entity);

            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<KorisnikResponse> Insert(KorisnikUpsertRequest request)
        {
            TipKorisnikaValidator.ValidateEntityExists(request.TipKorisnikaId);

            Korisnik entity = Mapper.Map<KorisnikUpsertRequest, Korisnik>(request);
            entity = Context.Set<Korisnik>().Add(entity).Entity;

            Context.SaveChanges();

            KorisnikResponse response = Mapper.Map<Korisnik, KorisnikResponse>(entity);

            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<KorisnikResponse> Update(int id, KorisnikUpsertRequest request)
        {
            Validator.ValidateEntityExists(id);
            TipKorisnikaValidator.ValidateEntityExists(request.TipKorisnikaId);

            Korisnik entity = Context.Set<Korisnik>().Find(id);

            entity = Mapper.Map(request, entity);

            Context.Set<Korisnik>().Update(entity);
            Context.SaveChanges();

            KorisnikResponse response = Mapper.Map<Korisnik, KorisnikResponse>(entity);

            return new PayloadResponse<KorisnikResponse>(HttpStatusCode.OK, response);

        }
    }
}
