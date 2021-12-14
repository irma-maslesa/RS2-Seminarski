using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class DataUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "hklyR0bGPePvT6VM8F8Q53JlybI=", "inH+Nnd7JfIACXRgWSueog==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "kDnLscyDsxPyJqhfu+9pZTXciz0=", "PabFZlYUgntExYLEirgu7Q==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Ue71zXkrJSD36HiZEBbm3dBpPw8=", "sNic063o8HGbpLpqEicn8g==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "3EPeyB0Lo5ysG5CkxXXByqepSCI=", "zXZGjF4V6Larv0O07omqMw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "zjJGW9cLeWwoyTZZrgoMwl5CJ6M=", "ykgdfPqDOVNhQymVyHCZRw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "4wnyI8bCD6D3ClHmU+RAosEYorc=", "wtqmfxhXLUreV5pf0LUstA==" });

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Prodaja",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 1,
                column: "Termin",
                value: new DateTime(2021, 12, 13, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 2,
                column: "Termin",
                value: new DateTime(2021, 12, 13, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 5,
                column: "Termin",
                value: new DateTime(2021, 12, 13, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 6,
                column: "Termin",
                value: new DateTime(2021, 12, 13, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "DatumProdano", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 15, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 15, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 13, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 15, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 13, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 347, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 347, DateTimeKind.Local).AddTicks(2919));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 348, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 348, DateTimeKind.Local).AddTicks(1747));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 348, DateTimeKind.Local).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 348, DateTimeKind.Local).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 356, DateTimeKind.Local).AddTicks(5300));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 356, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 356, DateTimeKind.Local).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "aNRSYJU976N4/phukgxqDxBF7pQ=", "xzLYpYiIGIU4b9a/NsQ2gw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "knQFWWB7CVlLq9K8NrclBo7b0SI=", "T8ME8/Cc93GW8FzNpqMeAg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Wi4pTsIZ1tT5Bf4qeKHMB1pL3Zc=", "2FetGaKQyPw3Denv+vladw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "RH6fnSPaGktDyJNdzaYOHn3yh1A=", "p4nl5SWPfyxuFsGUfFIpHQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "a796dfjoLgu08OH1dP0LjUipxq4=", "q6Nt3LJ2RCbL1rXFthxuaQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "BdWcJl5sPcLwUL260DoqhSoycKM=", "LOmZqABOmSGs44mEZYGBhA==" });

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 343, DateTimeKind.Local).AddTicks(6036));

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 346, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.UpdateData(
                table: "Prodaja",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 359, DateTimeKind.Local).AddTicks(6128));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 35, 11, 355, DateTimeKind.Local).AddTicks(4154), new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 35, 11, 355, DateTimeKind.Local).AddTicks(6708), new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 1,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 2,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 5,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 6,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "DatumProdano", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 35, 11, 357, DateTimeKind.Local).AddTicks(1368), new DateTime(2021, 12, 14, 16, 35, 11, 357, DateTimeKind.Local).AddTicks(2059), new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 35, 11, 357, DateTimeKind.Local).AddTicks(4391), new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
