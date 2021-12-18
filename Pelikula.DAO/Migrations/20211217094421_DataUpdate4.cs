using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class DataUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "2Yd75HJbOxa37E7J1/tZnDnkuP4=", "ThSG5PURS/q/8sw+lPhQQg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "NO5BE4Ooog/R27X+K8nSkMRthnk=", "L6EsdqAGZWRYu50J8E7LNw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "tVhJevDuLh/bkg0BaNtVl0/iClM=", "HOH3ewpfMr9/UR6At21zNA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "aMrZR85UbT/MwLlYzj1RoQVk6qM=", "27cEHojWmZtx/jx30R+TkQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "+i/X3oS9ceaT94VPqfW3jRFI5hw=", "XDUfvkOlXyGbx49vTgra+Q==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "3Wpf4bcp95SOZO/UHJVR9P0Dszk=", "rRmuN6XNvw65VwAKv2sVmw==" });

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Prodaja",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "VrijediDo", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600), new DateTime(2021, 12, 18, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediDo", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 17, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600), new DateTime(2021, 12, 18, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 1,
                column: "Termin",
                value: new DateTime(2021, 12, 16, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 2,
                column: "Termin",
                value: new DateTime(2021, 12, 16, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 3,
                column: "Termin",
                value: new DateTime(2021, 12, 18, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 4,
                column: "Termin",
                value: new DateTime(2021, 12, 18, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 5,
                column: "Termin",
                value: new DateTime(2021, 12, 16, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 6,
                column: "Termin",
                value: new DateTime(2021, 12, 16, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 7,
                column: "Termin",
                value: new DateTime(2021, 12, 18, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 8,
                column: "Termin",
                value: new DateTime(2021, 12, 18, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "DatumProdano", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 18, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600), new DateTime(2021, 12, 18, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600), new DateTime(2021, 12, 16, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 18, 10, 44, 20, 171, DateTimeKind.Local).AddTicks(600), new DateTime(2021, 12, 16, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Datum", "VrijediDo", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 15, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediDo", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 14, 10, 38, 23, 955, DateTimeKind.Local).AddTicks(2123), new DateTime(2021, 12, 15, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                keyValue: 3,
                column: "Termin",
                value: new DateTime(2021, 12, 15, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 4,
                column: "Termin",
                value: new DateTime(2021, 12, 15, 18, 40, 0, 0, DateTimeKind.Unspecified));

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
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 7,
                column: "Termin",
                value: new DateTime(2021, 12, 15, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 8,
                column: "Termin",
                value: new DateTime(2021, 12, 15, 18, 40, 0, 0, DateTimeKind.Unspecified));

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
    }
}
