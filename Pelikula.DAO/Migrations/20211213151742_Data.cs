using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pelikula.DAO.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmskaLicnost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(maxLength: 250, nullable: false),
                    Prezime = table.Column<string>(maxLength: 250, nullable: false),
                    IsReziser = table.Column<bool>(nullable: false),
                    IsGlumac = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmskaLicnost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JedinicaMjere",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KratkiNaziv = table.Column<string>(nullable: false),
                    Naziv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JedinicaMjere", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 250, nullable: false),
                    BrojSjedista = table.Column<int>(nullable: false),
                    BrojSjedistaDuzina = table.Column<int>(nullable: false),
                    BrojSjedistaSirina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnika",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKorisnika", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanr",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(maxLength: 250, nullable: false),
                    Opis = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanr", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JedinicaMjereID = table.Column<int>(nullable: false),
                    Sifra = table.Column<string>(maxLength: 20, nullable: false),
                    Naziv = table.Column<string>(maxLength: 250, nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Artikal_JedinicaMjere_JedinicaMjereId",
                        column: x => x.JedinicaMjereID,
                        principalTable: "JedinicaMjere",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sjediste",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Red = table.Column<string>(maxLength: 1, nullable: false),
                    Broj = table.Column<int>(nullable: false),
                    SalaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sjediste", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sjediste_Sala",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKorisnikaID = table.Column<int>(nullable: false),
                    KorisnickoIme = table.Column<string>(maxLength: 250, nullable: false),
                    LozinkaHash = table.Column<string>(maxLength: 250, nullable: true),
                    LozinkaSalt = table.Column<string>(maxLength: 250, nullable: true),
                    Ime = table.Column<string>(maxLength: 250, nullable: false),
                    Prezime = table.Column<string>(maxLength: 250, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    Spol = table.Column<string>(maxLength: 10, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true),
                    SlikaThumb = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_TipKorisnika",
                        column: x => x.TipKorisnikaID,
                        principalTable: "TipKorisnika",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(maxLength: 250, nullable: false),
                    Trajanje = table.Column<int>(nullable: false),
                    GodinaSnimanja = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(maxLength: 2000, nullable: true),
                    VideoLink = table.Column<string>(maxLength: 100, nullable: true),
                    ImdbLink = table.Column<string>(maxLength: 100, nullable: true),
                    Plakat = table.Column<byte[]>(nullable: true),
                    PlakatThumb = table.Column<byte[]>(nullable: true),
                    RediteljID = table.Column<int>(nullable: false),
                    ZanrID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Film_FilmskaLicnost_RediteljId",
                        column: x => x.RediteljID,
                        principalTable: "FilmskaLicnost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Film_Zanr_ZanrId",
                        column: x => x.ZanrID,
                        principalTable: "Zanr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Anketa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(maxLength: 250, nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    ZakljucenoDatum = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anketa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Anketa_Korisnik_KorisnikId",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    Naslov = table.Column<string>(maxLength: 250, nullable: false),
                    Tekst = table.Column<string>(maxLength: 2000, nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obavijest_Korisnik_KorisnikId",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmGlumac",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(nullable: false),
                    FilmskaLicnostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGlumac", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilmGlumacDodjela_Film_FilmId",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGlumacDodjela_FilmskaLicnost_FilmskaLicnostId",
                        column: x => x.FilmskaLicnostID,
                        principalTable: "FilmskaLicnost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projekcija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(nullable: false),
                    SalaID = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    VrijediOd = table.Column<DateTime>(nullable: false),
                    VrijediDo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekcija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projekcija_Film_FilmId",
                        column: x => x.FilmID,
                        principalTable: "Film",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekcija_Sala_SalaId",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnketaOdgovor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnketaID = table.Column<int>(nullable: false),
                    Odgovor = table.Column<string>(maxLength: 1000, nullable: false),
                    RedniBroj = table.Column<int>(nullable: false),
                    UkupnoIzabrano = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnketaOdgovor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnketaOdgovor_Anketa_AnketaId",
                        column: x => x.AnketaID,
                        principalTable: "Anketa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dojam",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjekcijaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    Ocjena = table.Column<int>(nullable: false),
                    Tekst = table.Column<string>(maxLength: 2000, nullable: true),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dojam", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dojam_Korisnik_KorisnikId",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dojam_Projekcija_ProjekcijaId",
                        column: x => x.ProjekcijaID,
                        principalTable: "Projekcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjekcijaKorisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjekcijaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    DatumPosjete = table.Column<DateTime>(nullable: false),
                    DatumPosljednjePosjete = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjekcijaKorisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjekcijaKorisnikDodjela_Korisnik_KorisnikId",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjekcijaKorisnikDodjela_Projekcija_ProjekcijaId",
                        column: x => x.ProjekcijaID,
                        principalTable: "Projekcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjekcijaTermin",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjekcijaID = table.Column<int>(nullable: false),
                    Termin = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjekcijaTermin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjekcijaTermin_Projekcija_ProjekcijaId",
                        column: x => x.ProjekcijaID,
                        principalTable: "Projekcija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnketaOdgovorKorisnik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnketaOdgovorID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnketaOdgovorKorisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnketaOdgovorKorisnikDodjela_AnketaOdgovor_AnketaOdgovorId",
                        column: x => x.AnketaOdgovorID,
                        principalTable: "AnketaOdgovor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnketaOdgovorKorisnikDodjela_Korisnik_KorisnikId",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    BrojSjedista = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    DatumProjekcije = table.Column<DateTime>(nullable: false),
                    DatumProdano = table.Column<DateTime>(nullable: true),
                    DatumOtkazano = table.Column<DateTime>(nullable: true),
                    ProjekcijaTerminID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikId",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_ProjekcijaTermin_ProjekcijaTerminId",
                        column: x => x.ProjekcijaTerminID,
                        principalTable: "ProjekcijaTermin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prodaja",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<string>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    RezervacijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodaja", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prodaja_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prodaja_Rezervacija",
                        column: x => x.RezervacijaId,
                        principalTable: "Rezervacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SjedisteRezervacija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SjedisteID = table.Column<int>(nullable: false),
                    RezervacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SjedisteRezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SjedisteRezervacija_Rezervacija",
                        column: x => x.RezervacijaID,
                        principalTable: "Rezervacija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SjedisteRezervacija_Sjediste",
                        column: x => x.SjedisteID,
                        principalTable: "Sjediste",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdajaArtikal",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdajaID = table.Column<int>(nullable: false),
                    ArtikalID = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdajaArtikal", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProdajaArtikalDodjela_Artikal_ArtikalId",
                        column: x => x.ArtikalID,
                        principalTable: "Artikal",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdajaArtikalDodjela_Prodaja_ProdajaId",
                        column: x => x.ProdajaID,
                        principalTable: "Prodaja",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FilmskaLicnost",
                columns: new[] { "ID", "Ime", "IsGlumac", "IsReziser", "Prezime" },
                values: new object[,]
                {
                    { 1, "Adam", true, true, "Sandler" },
                    { 17, "Denzel", true, true, "Washington" },
                    { 16, "Paula", true, false, "Patton" },
                    { 15, "Tony", false, true, "Scott" },
                    { 14, "Jay", true, false, "Elis" },
                    { 13, "Logan", true, true, "Miller" },
                    { 12, "Taylor", true, false, "Russel" },
                    { 11, "Adam", false, true, "Robitel" },
                    { 10, "Greta", false, true, "Gervig" },
                    { 18, "Jim", true, false, "Caviezel" },
                    { 8, "Penelope", true, true, "Cruise" },
                    { 7, "Nicole", true, false, "Kidman" },
                    { 6, "Natalie", true, false, "Portman" },
                    { 5, "Quentin", false, true, "Tarantino" },
                    { 4, "Arnold", true, true, "Schwarzenegger" },
                    { 3, "Antonio", true, true, "Banderas" },
                    { 2, "Al", true, true, "Pacino" },
                    { 9, "Sndra", true, true, "Bulock" }
                });

            migrationBuilder.InsertData(
                table: "JedinicaMjere",
                columns: new[] { "ID", "KratkiNaziv", "Naziv" },
                values: new object[,]
                {
                    { 1, "kom", "Komad" },
                    { 2, "kg", "Kilogram" },
                    { 3, "l", "Litar" }
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "ID", "BrojSjedista", "BrojSjedistaDuzina", "BrojSjedistaSirina", "Naziv" },
                values: new object[,]
                {
                    { 2, 42, 7, 6, "Sala 2" },
                    { 1, 42, 7, 6, "Sala 1" }
                });

            migrationBuilder.InsertData(
                table: "TipKorisnika",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Moderator" },
                    { 3, "Radnik" },
                    { 4, "Klijent" }
                });

            migrationBuilder.InsertData(
                table: "Zanr",
                columns: new[] { "ID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 8, "Romantika", "Žanr koji je fokusiran na strast, emocije i odnos privrženosti između glavnih likova." },
                    { 1, "Akcija", "Žanr u kojem dominiraju spektakularni akcijski prizori i brzo izmjenjujuće scene pune napetih događaja." },
                    { 2, "Avantura", "Žanr koji obiluje akcijom, potragom i egzotičnim lokacijama." },
                    { 3, "Komedija", "Žanr u kojem je naglasak stavljen na humor." },
                    { 4, "Drama", "Žanr koji najviše zavisi od unutrašnjeg razvoja likova koji se suočavaju s emocionalnim temama." },
                    { 5, "Fantazija", "Žanr u kojem dominiraju elementi natprirorodnog i izmišljenog." },
                    { 6, "Horor", "Žanr koji ima za cilj prenijeti osjećaj užasa i straha." },
                    { 7, "Misterija", "Žanr koji uključuje misterioznu smrt koju treba razriješiti." },
                    { 9, "Triler", "Žanr koji karakterišu dinamika, neprestana akcija i vješti junaci koji moraju osujetiti planove zlikovaca." }
                });

            migrationBuilder.InsertData(
                table: "Artikal",
                columns: new[] { "ID", "Cijena", "JedinicaMjereID", "Naziv", "Sifra", "Slika", "SlikaThumb" },
                values: new object[,]
                {
                    { 1, 3.5m, 1, "Male kokice", "000001", null, null },
                    { 2, 5m, 1, "Velike kokice", "000002", null, null },
                    { 3, 2.5m, 1, "Mala Coca-Cola", "000003", null, null },
                    { 4, 3m, 1, "Velika Coca-Cola", "000004", null, null }
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "ID", "GodinaSnimanja", "ImdbLink", "Naslov", "Plakat", "PlakatThumb", "RediteljID", "Sadrzaj", "Trajanje", "VideoLink", "ZanrID" },
                values: new object[,]
                {
                    { 1, 2006, "https://www.imdb.com/title/tt0453467/", "Deja Vu", null, null, 15, "Svi su iskusili neugodno iskustvo deja vua - djelić sjećanja kada upoznate osobu i osjećate kao da ste je poznavali cijeli život. Ili kad prepoznate mjesto premda nikad prije niste bili ondje. Što ako su ovi osjećaji zapravo upozorenja iz prošlosti ili predznaci budućnosti? U zanimljivom novom akcijskom trileru deja-vu neočekivano vodi agenta Douga Carlina kroz istragu do strašnog zločina. Premda je pozvan na mjesto zločina nakon što je bomba pokrenula kataklizmičnu eksploziju na trajektu u New Orleansu, Carlin će otkriti da je ono za što mnogi smatraju da je samo plod njihovog uma zapravo nešto puno snažnije - i to će ga odvesti u nezamislivu trku za spasom stotina nevinih ljudi.", 126, "https://www.youtube.com/watch?v=uxdS8TP37I4", 1 },
                    { 2, 2019, "https://www.imdb.com/title/tt5886046/", "Escape room", null, null, 11, "Četvoro prijatelja iz LA uzimaju učešće u poznatoj igri Escape Room, koju je osmislio izvesni Brice. Ali, shvate da se nađu zarobljeni od strabe demonski posednutog ubice. Prijatelji imaju manje od sat vremena da reše zagonetke i pobegnu iz zaključane sobe za smrtonosnu igru.", 109, "https://www.youtube.com/watch?v=6dSKUoV0SNI", 1 }
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "ID", "DatumRodjenja", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Slika", "SlikaThumb", "Spol", "TipKorisnikaID" },
                values: new object[,]
                {
                    { 6, new DateTime(2003, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile@pelikula.com", "Mobile", "Mobile", "HjVRn9pZwj2dVBWKtWL4rh0rVxM=", "gqwBnu7HNSJUraug36cAZg==", "Mobile", null, null, "Ž", 4 },
                    { 4, new DateTime(1999, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "klijent@pelikula.com", "Klijent", "Klijent", "6fxKbZyXpkwLKon0ozs4BMOGAGw=", "sWkc84DBv4WGLPoBp003DQ==", "Klijent", null, null, "Ž", 4 },
                    { 3, new DateTime(1996, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "radnik@pelikula.com", "Radnik", "Radnik", "Ua6OluYd97tniSfr/oMMbEL77co=", "ohEORm51T1tO41CbkKwpYg==", "Radnik", null, null, "M", 3 },
                    { 2, new DateTime(1979, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "moderator@pelikula.com", "Moderator", "Moderator", "CEE+vxPo2omQzJ9h3222NCslvC8=", "7am8pbjSx+QiR3vwxz93ZQ==", "Moderator", null, null, "Ž", 2 },
                    { 5, new DateTime(1974, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop@pelikula.com", "Desktop", "Desktop", "8GL4q3NluLXIeIurzyT1eAnQJ3E=", "OgbAn+eDm7QPn5Js4EWRAA==", "Desktop", null, null, "M", 1 },
                    { 1, new DateTime(1972, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "administrator@pelikula.com", "Administrator", "Administrator", "vqMSEqb93ZoSWChjIiKSyps9xl8=", "CLFkwUdGTaghCsk+xt+o4g==", "Administrator", null, null, "M", 1 }
                });

            migrationBuilder.InsertData(
                table: "Sjediste",
                columns: new[] { "ID", "Broj", "Red", "SalaID" },
                values: new object[,]
                {
                    { 3, 3, "A", 1 },
                    { 64, 4, "D", 2 },
                    { 63, 3, "D", 2 },
                    { 62, 2, "D", 2 },
                    { 61, 1, "D", 2 },
                    { 60, 6, "C", 2 },
                    { 59, 5, "C", 2 },
                    { 58, 4, "C", 2 },
                    { 54, 6, "B", 2 },
                    { 56, 2, "C", 2 },
                    { 55, 1, "C", 2 },
                    { 65, 5, "D", 2 },
                    { 53, 5, "B", 2 },
                    { 52, 4, "B", 2 },
                    { 51, 3, "B", 2 },
                    { 50, 2, "B", 2 },
                    { 57, 3, "C", 2 },
                    { 66, 6, "D", 2 },
                    { 70, 4, "E", 2 },
                    { 68, 2, "E", 2 },
                    { 84, 6, "G", 2 },
                    { 83, 5, "G", 2 },
                    { 82, 4, "G", 2 },
                    { 81, 3, "G", 2 },
                    { 80, 2, "G", 2 },
                    { 79, 1, "G", 2 },
                    { 78, 6, "F", 2 },
                    { 67, 1, "E", 2 },
                    { 77, 5, "F", 2 },
                    { 75, 3, "F", 2 },
                    { 74, 2, "F", 2 },
                    { 73, 1, "F", 2 },
                    { 72, 6, "E", 2 },
                    { 71, 5, "E", 2 },
                    { 49, 1, "B", 2 },
                    { 69, 3, "E", 2 },
                    { 76, 4, "F", 2 },
                    { 48, 6, "A", 2 },
                    { 47, 5, "A", 2 },
                    { 46, 4, "A", 2 },
                    { 22, 4, "D", 1 },
                    { 21, 3, "D", 1 },
                    { 20, 2, "D", 1 },
                    { 19, 1, "D", 1 },
                    { 18, 6, "C", 1 },
                    { 17, 5, "C", 1 },
                    { 16, 4, "C", 1 },
                    { 15, 3, "C", 1 },
                    { 14, 2, "C", 1 },
                    { 13, 1, "C", 1 },
                    { 12, 6, "B", 1 },
                    { 11, 5, "B", 1 },
                    { 10, 4, "B", 1 },
                    { 9, 3, "B", 1 },
                    { 8, 2, "B", 1 },
                    { 7, 1, "B", 1 },
                    { 6, 6, "A", 1 },
                    { 5, 5, "A", 1 },
                    { 4, 4, "A", 1 },
                    { 23, 5, "D", 1 },
                    { 2, 2, "A", 1 },
                    { 24, 6, "D", 1 },
                    { 26, 2, "E", 1 },
                    { 45, 3, "A", 2 },
                    { 1, 1, "A", 1 },
                    { 43, 1, "A", 2 },
                    { 42, 6, "G", 1 },
                    { 41, 5, "G", 1 },
                    { 40, 4, "G", 1 },
                    { 39, 3, "G", 1 },
                    { 38, 2, "G", 1 },
                    { 37, 1, "G", 1 },
                    { 36, 6, "F", 1 },
                    { 35, 5, "F", 1 },
                    { 34, 4, "F", 1 },
                    { 33, 3, "F", 1 },
                    { 32, 2, "F", 1 },
                    { 31, 1, "F", 1 },
                    { 30, 6, "E", 1 },
                    { 29, 5, "E", 1 },
                    { 28, 4, "E", 1 },
                    { 27, 3, "E", 1 },
                    { 25, 1, "E", 1 },
                    { 44, 2, "A", 2 }
                });

            migrationBuilder.InsertData(
                table: "Anketa",
                columns: new[] { "ID", "Datum", "KorisnikID", "Naslov", "ZakljucenoDatum" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 13, 16, 17, 41, 672, DateTimeKind.Local).AddTicks(3922), 1, "Omiljeni fimski žanr?", null },
                    { 2, new DateTime(2021, 12, 13, 16, 17, 41, 672, DateTimeKind.Local).AddTicks(4751), 2, "Omiljeni klasik?", null }
                });

            migrationBuilder.InsertData(
                table: "FilmGlumac",
                columns: new[] { "ID", "FilmID", "FilmskaLicnostID" },
                values: new object[,]
                {
                    { 1, 1, 16 },
                    { 2, 1, 17 },
                    { 3, 1, 18 },
                    { 4, 2, 12 },
                    { 5, 2, 13 },
                    { 6, 2, 14 }
                });

            migrationBuilder.InsertData(
                table: "Obavijest",
                columns: new[] { "ID", "Datum", "KorisnikID", "Naslov", "Tekst" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 13, 16, 17, 41, 668, DateTimeKind.Local).AddTicks(1998), 1, "Dobro došli!", "Dobro došli na informacijski sistem za podršku rada kino centra!" },
                    { 2, new DateTime(2021, 12, 13, 16, 17, 41, 670, DateTimeKind.Local).AddTicks(7983), 2, "Stigla je nova Pelikula aplikacija!", "Slušali smo vaše prijedloge te vam s ponosom predstavljamo novu Pelikula aplikaciju. Preuzmite novu Pelikula aplikaciju već danas! Nova aplikacija donosi nove značajke: digitalnu bonus karticu, jednostavnu i brzu kupovinu kinoulaznica te još mnogo toga." }
                });

            migrationBuilder.InsertData(
                table: "Projekcija",
                columns: new[] { "ID", "Cijena", "Datum", "FilmID", "SalaID", "VrijediDo", "VrijediOd" },
                values: new object[,]
                {
                    { 1, 7.5m, new DateTime(2021, 12, 13, 16, 17, 41, 677, DateTimeKind.Local).AddTicks(5219), 1, 1, new DateTime(2021, 12, 14, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5.5m, new DateTime(2021, 12, 13, 16, 17, 41, 677, DateTimeKind.Local).AddTicks(7499), 2, 2, new DateTime(2021, 12, 14, 23, 59, 59, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AnketaOdgovor",
                columns: new[] { "ID", "AnketaID", "Odgovor", "RedniBroj", "UkupnoIzabrano" },
                values: new object[,]
                {
                    { 1, 1, "Akcija", 1, 1 },
                    { 2, 1, "Fantazija", 2, 0 },
                    { 3, 1, "Komedija", 3, 0 },
                    { 4, 1, "Romantika", 4, 0 },
                    { 5, 1, "Horor", 5, 1 },
                    { 6, 2, "Bonnie i Clyde", 1, 0 },
                    { 7, 2, "Rosemaryno dijete", 2, 0 },
                    { 8, 2, "Kum", 3, 1 },
                    { 9, 2, "Pakleni šund", 4, 0 },
                    { 10, 2, "Isijavanje", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Dojam",
                columns: new[] { "ID", "Datum", "KorisnikID", "Ocjena", "ProjekcijaID", "Tekst" },
                values: new object[,]
                {
                    { 3, new DateTime(2021, 12, 13, 16, 17, 41, 678, DateTimeKind.Local).AddTicks(5985), 6, 5, 2, null },
                    { 1, new DateTime(2021, 12, 13, 16, 17, 41, 678, DateTimeKind.Local).AddTicks(5248), 4, 5, 1, "Odličan film, potpuno sam zadovoljan uslugama kina." },
                    { 2, new DateTime(2021, 12, 13, 16, 17, 41, 678, DateTimeKind.Local).AddTicks(5959), 6, 4, 1, "Kokice su bile preslane." }
                });

            migrationBuilder.InsertData(
                table: "ProjekcijaTermin",
                columns: new[] { "ID", "ProjekcijaID", "Termin" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 2, new DateTime(2021, 12, 14, 18, 40, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AnketaOdgovorKorisnik",
                columns: new[] { "ID", "AnketaOdgovorID", "Datum", "KorisnikID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(2770), 4 },
                    { 2, 5, new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(3494), 6 },
                    { 3, 7, new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(3520), 4 },
                    { 4, 10, new DateTime(2021, 12, 13, 16, 17, 41, 673, DateTimeKind.Local).AddTicks(3525), 6 }
                });

            migrationBuilder.InsertData(
                table: "Rezervacija",
                columns: new[] { "ID", "BrojSjedista", "Cijena", "Datum", "DatumOtkazano", "DatumProdano", "DatumProjekcije", "KorisnikID", "ProjekcijaTerminID" },
                values: new object[,]
                {
                    { 1, 2, 15m, new DateTime(2021, 12, 14, 16, 17, 41, 679, DateTimeKind.Local).AddTicks(1046), null, new DateTime(2021, 12, 14, 16, 17, 41, 679, DateTimeKind.Local).AddTicks(1710), new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 2, 1, 5.5m, new DateTime(2021, 12, 14, 16, 17, 41, 679, DateTimeKind.Local).AddTicks(3865), null, null, new DateTime(2021, 12, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "Prodaja",
                columns: new[] { "ID", "BrojRacuna", "Datum", "KorisnikId", "RezervacijaId" },
                values: new object[] { 1, "1234abc-def56", new DateTime(2021, 12, 13, 16, 17, 41, 680, DateTimeKind.Local).AddTicks(154), 3, 1 });

            migrationBuilder.InsertData(
                table: "SjedisteRezervacija",
                columns: new[] { "ID", "RezervacijaID", "SjedisteID" },
                values: new object[,]
                {
                    { 1, 1, 20 },
                    { 2, 1, 21 },
                    { 3, 2, 48 }
                });

            migrationBuilder.InsertData(
                table: "ProdajaArtikal",
                columns: new[] { "ID", "ArtikalID", "Kolicina", "ProdajaID" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Anketa_KorisnikId",
                table: "Anketa",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_AnketaOdgovor_AnketaId",
                table: "AnketaOdgovor",
                column: "AnketaID");

            migrationBuilder.CreateIndex(
                name: "IX_AnketaOdgovorKorisnikDodjela_AnketaOdgovorId",
                table: "AnketaOdgovorKorisnik",
                column: "AnketaOdgovorID");

            migrationBuilder.CreateIndex(
                name: "IX_AnketaOdgovorKorisnikDodjela_KorisnikId",
                table: "AnketaOdgovorKorisnik",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_JedinicaMjereId",
                table: "Artikal",
                column: "JedinicaMjereID");

            migrationBuilder.CreateIndex(
                name: "IX_Dojam_KorisnikId",
                table: "Dojam",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Dojam_ProjekcijaId",
                table: "Dojam",
                column: "ProjekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_RediteljId",
                table: "Film",
                column: "RediteljID");

            migrationBuilder.CreateIndex(
                name: "IX_Film_ZanrId",
                table: "Film",
                column: "ZanrID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGlumacDodjela_FilmId",
                table: "FilmGlumac",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGlumacDodjela_FilmskaLicnostId",
                table: "FilmGlumac",
                column: "FilmskaLicnostID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_TipKorisnikaId",
                table: "Korisnik",
                column: "TipKorisnikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijest_KorisnikId",
                table: "Obavijest",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Prodaja_KorisnikId",
                table: "Prodaja",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodaja_RezervacijaId",
                table: "Prodaja",
                column: "RezervacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdajaArtikalDodjela_ArtikalId",
                table: "ProdajaArtikal",
                column: "ArtikalID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdajaArtikalDodjela_ProdajaId",
                table: "ProdajaArtikal",
                column: "ProdajaID");

            migrationBuilder.CreateIndex(
                name: "IX_Projekcija_FilmId",
                table: "Projekcija",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_Projekcija_SalaId",
                table: "Projekcija",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjekcijaKorisnikDodjela_KorisnikId",
                table: "ProjekcijaKorisnik",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjekcijaKorisnikDodjela_ProjekcijaId",
                table: "ProjekcijaKorisnik",
                column: "ProjekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjekcijaTermin_ProjekcijaId",
                table: "ProjekcijaTermin",
                column: "ProjekcijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikId",
                table: "Rezervacija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_ProjekcijaTerminId",
                table: "Rezervacija",
                column: "ProjekcijaTerminID");

            migrationBuilder.CreateIndex(
                name: "IX_Sjediste_SalaID",
                table: "Sjediste",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_SjedisteRezervacija_RezervacijaID",
                table: "SjedisteRezervacija",
                column: "RezervacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_SjedisteRezervacija_SjedisteID",
                table: "SjedisteRezervacija",
                column: "SjedisteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnketaOdgovorKorisnik");

            migrationBuilder.DropTable(
                name: "Dojam");

            migrationBuilder.DropTable(
                name: "FilmGlumac");

            migrationBuilder.DropTable(
                name: "Obavijest");

            migrationBuilder.DropTable(
                name: "ProdajaArtikal");

            migrationBuilder.DropTable(
                name: "ProjekcijaKorisnik");

            migrationBuilder.DropTable(
                name: "SjedisteRezervacija");

            migrationBuilder.DropTable(
                name: "AnketaOdgovor");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Prodaja");

            migrationBuilder.DropTable(
                name: "Sjediste");

            migrationBuilder.DropTable(
                name: "Anketa");

            migrationBuilder.DropTable(
                name: "JedinicaMjere");

            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "ProjekcijaTermin");

            migrationBuilder.DropTable(
                name: "TipKorisnika");

            migrationBuilder.DropTable(
                name: "Projekcija");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "FilmskaLicnost");

            migrationBuilder.DropTable(
                name: "Zanr");
        }
    }
}
