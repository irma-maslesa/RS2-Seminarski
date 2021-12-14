using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class DataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 974, DateTimeKind.Local).AddTicks(6494));

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 974, DateTimeKind.Local).AddTicks(7319));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 975, DateTimeKind.Local).AddTicks(4390));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 975, DateTimeKind.Local).AddTicks(5053));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 975, DateTimeKind.Local).AddTicks(5077));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 975, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 981, DateTimeKind.Local).AddTicks(2944));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 981, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 981, DateTimeKind.Local).AddTicks(3641));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "oemFuFfP4PVnTigRO9mpDi0RSlQ=", "zt+GzG32pP+NQQIk3BeAhg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "NPBPvvZsdkw6Bd0zDFcsYSgehEY=", "168xARDpRdw+z40k63gd5A==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Z/qlh/MiNS7NvTviyckJTKxmN7A=", "5XDJ1AzxWpg+0x6kLYoo9Q==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "CRD74359+tby8yx0rclQMxOsFTQ=", "+aaNkidDFjxDGMrRvyT9zg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "DK/GsTcHMT/OZ8IzwtYxBlVscZo=", "lcOrzBpaFHv95FpcDR58Lw==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "hps5yNX/fDBJ+JaDxvyzRIFhE9w=", "mwpgoHD2x3GL0RCrqtN4Tg==" });

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 970, DateTimeKind.Local).AddTicks(6228));

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 973, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "Prodaja",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 982, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "VrijediDo" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 25, 44, 980, DateTimeKind.Local).AddTicks(2111), new DateTime(2021, 12, 15, 23, 59, 59, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediDo" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 25, 44, 980, DateTimeKind.Local).AddTicks(5243), new DateTime(2021, 12, 15, 23, 59, 59, 0, DateTimeKind.Unspecified) });

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
                columns: new[] { "Datum", "DatumProdano" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 25, 44, 981, DateTimeKind.Local).AddTicks(8306), new DateTime(2021, 12, 14, 16, 25, 44, 981, DateTimeKind.Local).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 16, 25, 44, 982, DateTimeKind.Local).AddTicks(939));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 672, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "Anketa",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 672, DateTimeKind.Local).AddTicks(4751));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "AnketaOdgovorKorisnik",
                keyColumn: "ID",
                keyValue: 4,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(3525));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 678, DateTimeKind.Local).AddTicks(5248));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 678, DateTimeKind.Local).AddTicks(5959));

            migrationBuilder.UpdateData(
                table: "Dojam",
                keyColumn: "ID",
                keyValue: 3,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 678, DateTimeKind.Local).AddTicks(5985));

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "vqMSEqb93ZoSWChjIiKSyps9xl8=", "CLFkwUdGTaghCsk+xt+o4g==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "CEE+vxPo2omQzJ9h3222NCslvC8=", "7am8pbjSx+QiR3vwxz93ZQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Ua6OluYd97tniSfr/oMMbEL77co=", "ohEORm51T1tO41CbkKwpYg==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "6fxKbZyXpkwLKon0ozs4BMOGAGw=", "sWkc84DBv4WGLPoBp003DQ==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "8GL4q3NluLXIeIurzyT1eAnQJ3E=", "OgbAn+eDm7QPn5Js4EWRAA==" });

            migrationBuilder.UpdateData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "HjVRn9pZwj2dVBWKtWL4rh0rVxM=", "gqwBnu7HNSJUraug36cAZg==" });

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 668, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Obavijest",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 670, DateTimeKind.Local).AddTicks(7983));

            migrationBuilder.UpdateData(
                table: "Prodaja",
                keyColumn: "ID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 17, 41, 680, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "VrijediDo" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 17, 41, 677, DateTimeKind.Local).AddTicks(5219), new DateTime(2021, 12, 14, 23, 59, 59, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "VrijediDo" },
                values: new object[] { new DateTime(2021, 12, 13, 16, 17, 41, 677, DateTimeKind.Local).AddTicks(7499), new DateTime(2021, 12, 14, 23, 59, 59, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 3,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 4,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 7,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ProjekcijaTermin",
                keyColumn: "ID",
                keyValue: 8,
                column: "Termin",
                value: new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "DatumProdano" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 17, 41, 679, DateTimeKind.Local).AddTicks(1046), new DateTime(2021, 12, 14, 16, 17, 41, 679, DateTimeKind.Local).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 14, 16, 17, 41, 679, DateTimeKind.Local).AddTicks(3865));
        }
    }
}
