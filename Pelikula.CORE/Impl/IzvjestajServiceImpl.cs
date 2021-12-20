using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pelikula.API.Api;
using Pelikula.API.Model.Izvjestaj;
using Pelikula.API.Model.Prodaja;
using Pelikula.API.Validation;
using Pelikula.CORE.Helper.Response;
using Pelikula.DAO;
using Pelikula.DAO.Model;
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
        protected readonly IZanrValidator ZanrValidator;

        public IzvjestajServiceImpl(AppDbContext context, IMapper mapper, IIzvjestajValidator validator, IZanrValidator zanrValidator) {
            Context = context;
            Mapper = mapper;
            Validator = validator;
            ZanrValidator = zanrValidator;
        }

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

        public ListPayloadResponse<IzvjestajPrometUGodiniResponse> GetPrometUGodini(int? zanrId) {
            if (zanrId.HasValue)
                ZanrValidator.ValidateEntityExists(zanrId.Value);

            var datum = DateTime.Now;

            IQueryable<Prodaja> entityList = Context.Prodaja
                .Include(e => e.Korisnik)
                .Include(e => e.ProdajaArtikal)
                    .ThenInclude(e => e.Artikal);

            if (zanrId.HasValue)
                entityList = entityList
                    .Include(e => e.Rezervacija)
                        .ThenInclude(e => e.ProjekcijaTermin)
                            .ThenInclude(e => e.Projekcija)
                                .ThenInclude(e => e.Film)
                    .Where(e => e.Rezervacija.ProjekcijaTermin.Projekcija.Film.ZanrId == zanrId
                                && e.Datum > datum.AddYears(-1) && e.Datum <= datum);
            else
                entityList = entityList.Include(e => e.Rezervacija)
                    .Where(e => e.Datum > datum.AddYears(-1) && e.Datum <= datum);

            var dtoList = Mapper.Map<List<ProdajaResponse>>(entityList.ToList());
            dtoList.ForEach(e => e.UkupnaCijena = e.GetUkupnaCijena(e.ProdajaArtikal, e.Rezervacija));

            var groupedByMonths = dtoList.GroupBy(e => e.Datum.Month).ToList();

            decimal sum = 0;
            var responseList = new List<IzvjestajPrometUGodiniResponse>();

            foreach (var month in groupedByMonths) {
                sum = month.Sum(e => e.UkupnaCijena);
                responseList.Add(new IzvjestajPrometUGodiniResponse {
                    Mjesec = ((Mjesec)month.Key).ToString(),
                    Promet = Math.Round(sum, 2)
                });
            }

            return new ListPayloadResponse<IzvjestajPrometUGodiniResponse>(HttpStatusCode.OK, responseList);
        }

        public ListPayloadResponse<IzvjestajOdnosOnlineInstore> GetOdnosOnlineInstore(DateTime? datumOd, DateTime? datumDo) {
            IQueryable<Prodaja> entityList = Context.Prodaja;

            if (datumOd.HasValue || datumDo.HasValue) {
                Validator.ValidateDatume(datumOd.Value, datumDo.Value);

                entityList = entityList
                .Where(e => e.Datum >= datumOd && e.Datum <= datumDo);
            }
            else {
                var _datumOd = entityList.Min(e => e.Datum);
                var _datumDo = entityList.Max(e => e.Datum);
                datumOd = new DateTime(_datumOd.Year, _datumOd.Month, _datumOd.Day, 0, 0, 0);
                datumDo = new DateTime(_datumDo.Year, _datumDo.Month, _datumDo.Day, 23, 59, 59);
            }



            var responseList = new List<IzvjestajOdnosOnlineInstore> {
                new IzvjestajOdnosOnlineInstore {
                    Tip = IzvjestajOdnosOnlineInstore.IzvjestajOdnosOnlineInstoreTip.ONLINE.ToString(),
                    Count = entityList.Count(e => e.KorisnikId == null),
                    DatumOd = datumOd.Value,
                    DatumDo = datumDo.Value
                },
                new IzvjestajOdnosOnlineInstore {
                    Tip = IzvjestajOdnosOnlineInstore.IzvjestajOdnosOnlineInstoreTip.IN_STORE.ToString(),
                    Count = entityList.Count(e => e.KorisnikId != null),
                    DatumOd = datumOd.Value,
                    DatumDo = datumDo.Value
                }
            };

            return new ListPayloadResponse<IzvjestajOdnosOnlineInstore>(HttpStatusCode.OK, responseList);
        }

        public ListPayloadResponse<IzvjestajTopKorisnici> GetTopKorisnici(int? brojKorisnika, int? zanrId) {
            IQueryable<Prodaja> entityList = Context.Prodaja
                .Include(e => e.ProdajaArtikal)
                    .ThenInclude(e => e.Artikal)
                .Include(e => e.Rezervacija)
                    .ThenInclude(e => e.Korisnik);

            if (zanrId.HasValue) {
                ZanrValidator.ValidateEntityExists(zanrId.Value);
                entityList = entityList.Include(e => e.Rezervacija)
                        .ThenInclude(e => e.ProjekcijaTermin)
                            .ThenInclude(e => e.Projekcija)
                                .ThenInclude(e => e.Film)
                        .Where(e => e.Rezervacija.ProjekcijaTermin.Projekcija.Film.ZanrId == zanrId);
            }
            if (!brojKorisnika.HasValue)
                brojKorisnika = 5;

            var dtoList = Mapper.Map<List<ProdajaResponse>>(entityList);
            dtoList.ForEach(e => e.UkupnaCijena = e.GetUkupnaCijena(e.ProdajaArtikal, e.Rezervacija));

            var groupedByKorisnici = dtoList.GroupBy(e => e.Rezervacija.Korisnik).ToList();
            groupedByKorisnici = groupedByKorisnici.OrderByDescending(e => e.Count()).Take(brojKorisnika.Value).ToList();

            var responseList = new List<IzvjestajTopKorisnici>();

            foreach (var korisnik in groupedByKorisnici) {
                responseList.Add(new IzvjestajTopKorisnici {
                    Korisnik = korisnik.Key.ToString(),
                    BrojKupovina = korisnik.Count(),
                    BrojKarti = korisnik.Sum(e => e.Rezervacija.BrojSjedista),
                    UkupnaCijena = korisnik.Sum(e => e.UkupnaCijena)
                });
            }

            responseList = responseList.OrderByDescending(e => e.BrojKupovina)
                .ThenByDescending(e => e.UkupnaCijena)
                .ThenByDescending(e => e.BrojKarti)
                .ToList();

            return new ListPayloadResponse<IzvjestajTopKorisnici>(HttpStatusCode.OK, responseList);
        }

        enum Mjesec
        {
            Januar = 1, Februar, Mart, April, Maj, Juni, Juli, August, Septembar, Oktobar, Novembar, Decembar
        }
    }
}
