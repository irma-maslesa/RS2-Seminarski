using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class DataUpdate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Prodaja",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "fHJgMqK7OKuJbrPa7XWfnay9IUE=", "r/Dr6HiYw+5MSSJKq/Z8Kg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "fYvQ++XJkutmgwut7BqvVWF68JQ=", "RkvnsiqkHnBCPjFvciSsxA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Y20P2KS7xpdEWVOgZIllZjfI88c=", "Rj//kJeEXQOSGN1talA1KA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "bfzXOYsYC/hkw+sRe3unP2IAErg=", "/TkSQaXG7P7vn9VRilrxaw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "LQ45OxHnjg8P+xJOCTPw40IohUg=", "7T+aYOX5GQCAirH9U2oNaw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "B9AIB/QKceAEaeBUMotqgfGrRas=", "LDAV+sOTOn8cqRgXglSZSA==" });

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Prodaja",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "VrijediDo", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943), new DateTime(2021, 12, 21, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediDo", "VrijediOd" },
                values: new object[] { new DateTime(2021, 12, 20, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943), new DateTime(2021, 12, 21, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 1,
                column: "Termin",
                value: new DateTime(2021, 12, 19, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 2,
                column: "Termin",
                value: new DateTime(2021, 12, 19, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 3,
                column: "Termin",
                value: new DateTime(2021, 12, 21, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 4,
                column: "Termin",
                value: new DateTime(2021, 12, 21, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 5,
                column: "Termin",
                value: new DateTime(2021, 12, 19, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 6,
                column: "Termin",
                value: new DateTime(2021, 12, 19, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 7,
                column: "Termin",
                value: new DateTime(2021, 12, 21, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 8,
                column: "Termin",
                value: new DateTime(2021, 12, 21, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "DatumProdano", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 21, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943), new DateTime(2021, 12, 21, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943), new DateTime(2021, 12, 19, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "DatumProjekcije" },
                values: new object[] { new DateTime(2021, 12, 21, 19, 47, 40, 219, DateTimeKind.Local).AddTicks(5943), new DateTime(2021, 12, 19, 13, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Prodaja",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
