using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model;
using Pelikula.API.Model.Helper;
using Pelikula.API.Model.Izvjestaj;
using Pelikula.API.Model.Prodaja;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pelikula.CORE.Impl
{
    public class IzvjestajServiceImpl :
        IIzvjestajService
    {
        protected AppDbContext Context { get; set; }
        protected readonly IMapper Mapper;
        protected readonly IIzvjestajValidator Validator;

        public IzvjestajServiceImpl(AppDbContext context, IMapper mapper, IIzvjestajValidator validator) {
            Context = context;
            Mapper = mapper;
            Validator = validator;
        }

        //public virtual PagedPayloadResponse<LoV> GetLoVs(PaginationUtility.PaginationParams pagination, IEnumerable<FilterUtility.FilterParams> filter = null, IEnumerable<SortingUtility.SortingParams> sorting = null) {
        //    IEnumerable<Entity> entityList = Context.Set<Entity>().ToList();

        //    entityList = filter != null && filter.Any() ? FilterUtility.Filter<Entity>.FilteredData(filter, entityList) : entityList;
        //    entityList = sorting != null && sorting.Any() ? SortingUtility.Sorting<Entity>.SortData(sorting, entityList) : entityList;

        //    List<LoV> responseList = Mapper.Map<List<LoV>>(entityList);

        //    PaginationUtility.PagedData<LoV> pagedResponse = PaginationUtility.Paginaion<LoV>.PaginateData(responseList, pagination);
        //    return new PagedPayloadResponse<LoV>(HttpStatusCode.OK, pagedResponse);
        //}

        public ListPayloadResponse<IzvjestajProdajaPoDatumuResponse> GetProdajaPoDatumu(DateTime datumOd, DateTime datumDo) {
            Validator.ValidateDatume(datumOd, datumDo);
            
            var entityList = Context.Prodaja
                .Include(e => e.Korisnik)
                .Include(e => e.ProdajaArtikal)
                    .ThenInclude(e => e.Artikal)
                .Include(e => e.Rezervacija)
                .Where(e => e.Datum >= datumOd && e.Datum <= datumDo)
                .ToList();

            var dtoList = Mapper.Map<List<ProdajaResponse>>(entityList);
            dtoList.ForEach(e => e.UkupnaCijena = e.GetUkupnaCijena(e.ProdajaArtikal, e.Rezervacija));

            var responseList = Mapper.Map<List<IzvjestajProdajaPoDatumuResponse>>(dtoList);
            return new ListPayloadResponse<IzvjestajProdajaPoDatumuResponse>(HttpStatusCode.OK, responseList);
        }
    }
}
