using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class DataUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 355, DateTimeKind.Local).AddTicks(4154));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 35, 11, 355, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Datum", "DatumProdano" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 35, 11, 357, DateTimeKind.Local).AddTicks(1368), new DateTime(2021, 12, 14, 16, 35, 11, 357, DateTimeKind.Local).AddTicks(2059) });

            migrationBuilder.UpdateData(
                table: "Rezervacija",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Datum", "ProjekcijaTerminID" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 35, 11, 357, DateTimeKind.Local).AddTicks(4391), 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 980, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Projekcija",
                keyColumn: "ID",
                keyValue: 2,
                column: "Datum",
                value: new DateTime(2021, 12, 13, 16, 25, 44, 980, DateTimeKind.Local).AddTicks(5243));

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
                columns: new[] { "Datum", "ProjekcijaTerminID" },
                values: new object[] { new DateTime(2021, 12, 14, 16, 25, 44, 982, DateTimeKind.Local).AddTicks(939), 3 });
        }
    }
}
