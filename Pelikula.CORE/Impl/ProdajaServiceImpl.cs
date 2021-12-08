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

namespace Pelikula.CORE.Impl
{
    public class ProdajaServiceImpl :
        CrudServiceImpl<ProdajaResponse, Prodaja, ProdajaInsertRequest, object>,
        IProdajaService
    {
        protected IJedinicaMjereValidator JedinicaMjereValidator { get; set; }

        public ProdajaServiceImpl(AppDbContext context, IMapper mapper, IProdajaValidator validator, IJedinicaMjereValidator korisnikValidator) : base(context, mapper, validator)
        {
            JedinicaMjereValidator = korisnikValidator;
        }

        public override PagedPayloadResponse<ProdajaResponse> Get(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null)
        {
            IEnumerable<Prodaja> entityList = Context.Set<Prodaja>().ToList();

            entityList = filter != null && filter.Any() ? FilterUtility.Filter<Prodaja>.FilteredData(filter, entityList) : entityList;
            entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Prodaja>.SortData(sorting, entityList) : entityList;

            List<ProdajaResponse> responseList = Mapper.Map<List<ProdajaResponse>>(entityList);

            PaginationUtility.PagedData<ProdajaResponse> pagedResponse = PaginationUtility.Paginaion<ProdajaResponse>.PaginateData(responseList, pagination);
            return new PagedPayloadResponse<ProdajaResponse>(HttpStatusCode.OK, pagedResponse);
        }

        public override PayloadResponse<ProdajaResponse> GetById(int id)
        {
            Validator.ValidateEntityExists(id);

            Prodaja entity = Context.Set<Prodaja>().FirstOrDefault(e => e.Id == id);

            ProdajaResponse response = Mapper.Map<ProdajaResponse>(entity);

            return new PayloadResponse<ProdajaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ProdajaResponse> Insert(ProdajaInsertRequest request)
        {
            Prodaja entity = Mapper.Map<ProdajaInsertRequest, Prodaja>(request);
            //entity.Sifra = GenerateSifra();

            entity = Context.Set<Prodaja>().Add(entity).Entity;

            Context.SaveChanges();

            ProdajaResponse response = Mapper.Map<Prodaja, ProdajaResponse>(entity);
            return new PayloadResponse<ProdajaResponse>(HttpStatusCode.OK, response);
        }

        public override PayloadResponse<ProdajaResponse> Update(int id, object request)
        {
            throw new UserException("Update prodaje nije moguć!", HttpStatusCode.NotFound);
        }

        //private string GenerateSifra()
        //{

        //    var najvecaSifra = Context.Prodaja
        //        .OrderByDescending(e => e.Sifra)
        //        .Select(e => e.Sifra)
        //        .FirstOrDefault();

        //    if (najvecaSifra != null)
        //    {
        //        if (int.TryParse(najvecaSifra, out int sifra))
        //            return string.Format("{0:D6}", ++sifra);
        //        else
        //            throw new UserException("Nemoguće postavljanje šifre!", HttpStatusCode.BadRequest);
        //    }
        //    else
        //    {
        //        return string.Format("{0:D6}", 1);
        //    }
        //}

    }
}
