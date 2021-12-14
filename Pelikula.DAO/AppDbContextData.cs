using Microsoft.EntityFrameworkCore;
using Pelikula.DAO.Model;
using System;
using System.Collections.Generic;

namespace Pelikula.DAO
{
    public partial class AppDbContext
    {
        private DateTime datum = DateTime.Now;

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TipKorisnika>()
                .HasData
                (
                    new TipKorisnika { Id = 1, Naziv = "Administrator" },
                    new TipKorisnika { Id = 2, Naziv = "Moderator" },
                    new TipKorisnika { Id = 3, Naziv = "Radnik" },
                    new TipKorisnika { Id = 4, Naziv = "Klijent" }
                );

            List<string> _salts = new List<string>();
            for (int i = 0; i < 6; i++) {
                _salts.Add(PasswordHelper.GenerateSalt());
            }
            modelBuilder.Entity<Korisnik>()
                .HasData
                (
                    new Korisnik {
                        Id = 1,
                        TipKorisnikaId = 1,
                        KorisnickoIme = "Administrator",
                        LozinkaSalt = _salts[0],
                        LozinkaHash = PasswordHelper.GenerateHash(_salts[0], "test"),
                        Ime = "Administrator",
                        Prezime = "Administrator",
                        Email = "administrator@pelikula.com",
                        Spol = "M",
                        DatumRodjenja = new DateTime(1972, 10, 2)
                    },
                    new Korisnik {
                        Id = 2,
                        TipKorisnikaId = 2,
                        KorisnickoIme = "Moderator",
                        LozinkaSalt = _salts[1],
                        LozinkaHash = PasswordHelper.GenerateHash(_salts[1], "test"),
                        Ime = "Moderator",
                        Prezime = "Moderator",
                        Email = "moderator@pelikula.com",
                        Spol = "Ž",
                        DatumRodjenja = new DateTime(1979, 11, 9)
                    },
                    new Korisnik {
                        Id = 3,
                        TipKorisnikaId = 3,
                        KorisnickoIme = "Radnik",
                        LozinkaSalt = _salts[2],
                        LozinkaHash = PasswordHelper.GenerateHash(_salts[2], "test"),
                        Ime = "Radnik",
                        Prezime = "Radnik",
                        Email = "radnik@pelikula.com",
                        Spol = "M",
                        DatumRodjenja = new DateTime(1996, 8, 17)
                    },
                    new Korisnik {
                        Id = 4,
                        TipKorisnikaId = 4,
                        KorisnickoIme = "Klijent",
                        LozinkaSalt = _salts[3],
                        LozinkaHash = PasswordHelper.GenerateHash(_salts[3], "test"),
                        Ime = "Klijent",
                        Prezime = "Klijent",
                        Email = "klijent@pelikula.com",
                        Spol = "Ž",
                        DatumRodjenja = new DateTime(1999, 11, 23)
                    },
                    new Korisnik {
                        Id = 5,
                        TipKorisnikaId = 1,
                        KorisnickoIme = "Desktop",
                        LozinkaSalt = _salts[4],
                        LozinkaHash = PasswordHelper.GenerateHash(_salts[4], "test"),
                        Ime = "Desktop",
                        Prezime = "Desktop",
                        Email = "desktop@pelikula.com",
                        Spol = "M",
                        DatumRodjenja = new DateTime(1974, 7, 17)
                    },
                    new Korisnik {
                        Id = 6,
                        TipKorisnikaId = 4,
                        KorisnickoIme = "Mobile",
                        LozinkaSalt = _salts[5],
                        LozinkaHash = PasswordHelper.GenerateHash(_salts[5], "test"),
                        Ime = "Mobile",
                        Prezime = "Mobile",
                        Email = "mobile@pelikula.com",
                        Spol = "Ž",
                        DatumRodjenja = new DateTime(2003, 12, 8)
                    }
                );

            modelBuilder.Entity<Zanr>()
                .HasData(
                    new Zanr {
                        Id = 1,
                        Naziv = "Akcija",
                        Opis = "Žanr u kojem dominiraju spektakularni akcijski prizori i brzo izmjenjujuće scene pune napetih događaja."
                    },
                    new Zanr {
                        Id = 2,
                        Naziv = "Avantura",
                        Opis = "Žanr koji obiluje akcijom, potragom i egzotičnim lokacijama."
                    },
                    new Zanr {
                        Id = 3,
                        Naziv = "Komedija",
                        Opis = "Žanr u kojem je naglasak stavljen na humor."
                    },
                    new Zanr {
                        Id = 4,
                        Naziv = "Drama",
                        Opis = "Žanr koji najviše zavisi od unutrašnjeg razvoja likova koji se suočavaju s emocionalnim temama."
                    },
                    new Zanr {
                        Id = 5,
                        Naziv = "Fantazija",
                        Opis = "Žanr u kojem dominiraju elementi natprirorodnog i izmišljenog."
                    },
                    new Zanr {
                        Id = 6,
                        Naziv = "Horor",
                        Opis = "Žanr koji ima za cilj prenijeti osjećaj užasa i straha."
                    },
                    new Zanr {
                        Id = 7,
                        Naziv = "Misterija",
                        Opis = "Žanr koji uključuje misterioznu smrt koju treba razriješiti."
                    },
                    new Zanr {
                        Id = 8,
                        Naziv = "Romantika",
                        Opis = "Žanr koji je fokusiran na strast, emocije i odnos privrženosti između glavnih likova."
                    },
                    new Zanr {
                        Id = 9,
                        Naziv = "Triler",
                        Opis = "Žanr koji karakterišu dinamika, neprestana akcija i vješti junaci koji moraju osujetiti planove zlikovaca."
                    }
                );

            modelBuilder.Entity<JedinicaMjere>()
                .HasData(
                    new JedinicaMjere { Id = 1, Naziv = "Komad", KratkiNaziv = "kom" },
                    new JedinicaMjere { Id = 2, Naziv = "Kilogram", KratkiNaziv = "kg" },
                    new JedinicaMjere { Id = 3, Naziv = "Litar", KratkiNaziv = "l" }
                );

            modelBuilder.Entity<Obavijest>()
                .HasData(
                    new Obavijest {
                        Id = 1,
                        KorisnikId = 1,
                        Naslov = "Dobro došli!",
                        Tekst = "Dobro došli na informacijski sistem za podršku rada kino centra!",
                        Datum = datum
                    },
                    new Obavijest {
                        Id = 2,
                        KorisnikId = 2,
                        Naslov = "Stigla je nova Pelikula aplikacija!",
                        Tekst = "Slušali smo vaše prijedloge te vam s ponosom predstavljamo novu Pelikula aplikaciju. Preuzmite novu Pelikula aplikaciju već danas! Nova aplikacija donosi nove značajke: digitalnu bonus karticu, jednostavnu i brzu kupovinu kinoulaznica te još mnogo toga.",
                        Datum = datum
                    }
                );

            modelBuilder.Entity<Anketa>()
               .HasData(
                    new Anketa {
                        Id = 1,
                        KorisnikId = 1,
                        Naslov = "Omiljeni fimski žanr?",
                        Datum = datum
                    },
                    new Anketa {
                        Id = 2,
                        KorisnikId = 2,
                        Naslov = "Omiljeni klasik?",
                        Datum = datum
                    }
                );

            modelBuilder.Entity<AnketaOdgovor>()
              .HasData(
                   new AnketaOdgovor {
                       Id = 1,
                       AnketaId = 1,
                       Odgovor = "Akcija",
                       RedniBroj = 1,
                       UkupnoIzabrano = 1
                   },
                   new AnketaOdgovor {
                       Id = 2,
                       AnketaId = 1,
                       Odgovor = "Fantazija",
                       RedniBroj = 2,
                       UkupnoIzabrano = 0
                   },
                   new AnketaOdgovor {
                       Id = 3,
                       AnketaId = 1,
                       Odgovor = "Komedija",
                       RedniBroj = 3,
                       UkupnoIzabrano = 0
                   },
                   new AnketaOdgovor {
                       Id = 4,
                       AnketaId = 1,
                       Odgovor = "Romantika",
                       RedniBroj = 4,
                       UkupnoIzabrano = 0
                   },
                   new AnketaOdgovor {
                       Id = 5,
                       AnketaId = 1,
                       Odgovor = "Horor",
                       RedniBroj = 5,
                       UkupnoIzabrano = 1
                   },
                   new AnketaOdgovor {
                       Id = 6,
                       AnketaId = 2,
                       Odgovor = "Bonnie i Clyde",
                       RedniBroj = 1,
                       UkupnoIzabrano = 0
                   },
                   new AnketaOdgovor {
                       Id = 7,
                       AnketaId = 2,
                       Odgovor = "Rosemaryno dijete",
                       RedniBroj = 2,
                       UkupnoIzabrano = 0
                   },
                   new AnketaOdgovor {
                       Id = 8,
                       AnketaId = 2,
                       Odgovor = "Kum",
                       RedniBroj = 3,
                       UkupnoIzabrano = 1
                   },
                   new AnketaOdgovor {
                       Id = 9,
                       AnketaId = 2,
                       Odgovor = "Pakleni šund",
                       RedniBroj = 4,
                       UkupnoIzabrano = 0
                   },
                   new AnketaOdgovor {
                       Id = 10,
                       AnketaId = 2,
                       Odgovor = "Isijavanje",
                       RedniBroj = 5,
                       UkupnoIzabrano = 1
                   }
               );

            modelBuilder.Entity<AnketaOdgovorKorisnik>()
                .HasData(
                    new AnketaOdgovorKorisnik {
                        Id = 1,
                        AnketaOdgovorId = 1,
                        KorisnikId = 4,
                        Datum = datum
                    },
                    new AnketaOdgovorKorisnik {
                        Id = 2,
                        AnketaOdgovorId = 5,
                        KorisnikId = 6,
                        Datum = datum
                    },
                    new AnketaOdgovorKorisnik {
                        Id = 3,
                        AnketaOdgovorId = 7,
                        KorisnikId = 4,
                        Datum = datum
                    },
                    new AnketaOdgovorKorisnik {
                        Id = 4,
                        AnketaOdgovorId = 10,
                        KorisnikId = 6,
                        Datum = datum
                    }
                );

            modelBuilder.Entity<Artikal>()
                .HasData(
                    new Artikal {
                        Id = 1,
                        JedinicaMjereId = 1,
                        Sifra = "000001",
                        Naziv = "Male kokice",
                        Cijena = 3.5M
                    },
                    new Artikal {
                        Id = 2,
                        JedinicaMjereId = 1,
                        Sifra = "000002",
                        Naziv = "Velike kokice",
                        Cijena = 5M
                    },
                    new Artikal {
                        Id = 3,
                        JedinicaMjereId = 1,
                        Sifra = "000003",
                        Naziv = "Mala Coca-Cola",
                        Cijena = 2.5M
                    },
                    new Artikal {
                        Id = 4,
                        JedinicaMjereId = 1,
                        Sifra = "000004",
                        Naziv = "Velika Coca-Cola",
                        Cijena = 3M
                    }
                );

            modelBuilder.Entity<FilmskaLicnost>()
                .HasData(
                    new FilmskaLicnost {
                        Id = 1,
                        Ime = "Adam",
                        Prezime = "Sandler",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 2,
                        Ime = "Al",
                        Prezime = "Pacino",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 3,
                        Ime = "Antonio",
                        Prezime = "Banderas",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 4,
                        Ime = "Arnold",
                        Prezime = "Schwarzenegger",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 5,
                        Ime = "Quentin",
                        Prezime = "Tarantino",
                        IsGlumac = false,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 6,
                        Ime = "Natalie",
                        Prezime = "Portman",
                        IsGlumac = true,
                        IsReziser = false
                    },
                    new FilmskaLicnost {
                        Id = 7,
                        Ime = "Nicole",
                        Prezime = "Kidman",
                        IsGlumac = true,
                        IsReziser = false
                    },
                    new FilmskaLicnost {
                        Id = 8,
                        Ime = "Penelope",
                        Prezime = "Cruise",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 9,
                        Ime = "Sndra",
                        Prezime = "Bulock",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 10,
                        Ime = "Greta",
                        Prezime = "Gervig",
                        IsGlumac = false,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 11,
                        Ime = "Adam",
                        Prezime = "Robitel",
                        IsGlumac = false,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 12,
                        Ime = "Taylor",
                        Prezime = "Russel",
                        IsGlumac = true,
                        IsReziser = false
                    },
                    new FilmskaLicnost {
                        Id = 13,
                        Ime = "Logan",
                        Prezime = "Miller",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 14,
                        Ime = "Jay",
                        Prezime = "Elis",
                        IsGlumac = true,
                        IsReziser = false
                    },
                    new FilmskaLicnost {
                        Id = 15,
                        Ime = "Tony",
                        Prezime = "Scott",
                        IsGlumac = false,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 16,
                        Ime = "Paula",
                        Prezime = "Patton",
                        IsGlumac = true,
                        IsReziser = false
                    },
                    new FilmskaLicnost {
                        Id = 17,
                        Ime = "Denzel",
                        Prezime = "Washington",
                        IsGlumac = true,
                        IsReziser = true
                    },
                    new FilmskaLicnost {
                        Id = 18,
                        Ime = "Jim",
                        Prezime = "Caviezel",
                        IsGlumac = true,
                        IsReziser = false
                    }
                );

            modelBuilder.Entity<Film>()
                .HasData(
                    new Film {
                        Id = 1,
                        Naslov = "Deja Vu",
                        Trajanje = 126,
                        GodinaSnimanja = 2006,
                        Sadrzaj = "Svi su iskusili neugodno iskustvo deja vua - djelić sjećanja kada upoznate osobu i osjećate kao da ste je poznavali cijeli život. Ili kad prepoznate mjesto premda nikad prije niste bili ondje. Što ako su ovi osjećaji zapravo upozorenja iz prošlosti ili predznaci budućnosti? U zanimljivom novom akcijskom trileru deja-vu neočekivano vodi agenta Douga Carlina kroz istragu do strašnog zločina. Premda je pozvan na mjesto zločina nakon što je bomba pokrenula kataklizmičnu eksploziju na trajektu u New Orleansu, Carlin će otkriti da je ono za što mnogi smatraju da je samo plod njihovog uma zapravo nešto puno snažnije - i to će ga odvesti u nezamislivu trku za spasom stotina nevinih ljudi.",
                        VideoLink = "https://www.youtube.com/watch?v=uxdS8TP37I4",
                        ImdbLink = "https://www.imdb.com/title/tt0453467/",
                        RediteljId = 15,
                        ZanrId = 1
                    },
                    new Film {
                        Id = 2,
                        Naslov = "Escape room",
                        Trajanje = 109,
                        GodinaSnimanja = 2019,
                        Sadrzaj = "Četvoro prijatelja iz LA uzimaju učešće u poznatoj igri Escape Room, koju je osmislio izvesni Brice. Ali, shvate da se nađu zarobljeni od strabe demonski posednutog ubice. Prijatelji imaju manje od sat vremena da reše zagonetke i pobegnu iz zaključane sobe za smrtonosnu igru.",
                        VideoLink = "https://www.youtube.com/watch?v=6dSKUoV0SNI",
                        ImdbLink = "https://www.imdb.com/title/tt5886046/",
                        RediteljId = 11,
                        ZanrId = 1
                    }
                );

            modelBuilder.Entity<FilmGlumac>()
                .HasData(
                    new FilmGlumac {
                        Id = 1,
                        FilmId = 1,
                        FilmskaLicnostId = 16
                    },
                    new FilmGlumac {
                        Id = 2,
                        FilmId = 1,
                        FilmskaLicnostId = 17
                    },
                    new FilmGlumac {
                        Id = 3,
                        FilmId = 1,
                        FilmskaLicnostId = 18
                    },
                    new FilmGlumac {
                        Id = 4,
                        FilmId = 2,
                        FilmskaLicnostId = 12
                    },
                    new FilmGlumac {
                        Id = 5,
                        FilmId = 2,
                        FilmskaLicnostId = 13
                    },
                    new FilmGlumac {
                        Id = 6,
                        FilmId = 2,
                        FilmskaLicnostId = 14
                    }
                );

            modelBuilder.Entity<Sala>()
                .HasData(
                    new Sala {
                        Id = 1,
                        Naziv = "Sala 1",
                        BrojSjedista = 42,
                        BrojSjedistaDuzina = 7,
                        BrojSjedistaSirina = 6
                    },
                    new Sala {
                        Id = 2,
                        Naziv = "Sala 2",
                        BrojSjedista = 42,
                        BrojSjedistaDuzina = 7,
                        BrojSjedistaSirina = 6
                    }
                );

            modelBuilder.Entity<Sjediste>()
               .HasData(
                   new Sjediste {
                       Id = 1,
                       Red = "A",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 2,
                       Red = "A",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 3,
                       Red = "A",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 4,
                       Red = "A",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 5,
                       Red = "A",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 6,
                       Red = "A",
                       Broj = 6,
                       SalaId = 1
                   },

                   new Sjediste {
                       Id = 7,
                       Red = "B",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 8,
                       Red = "B",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 9,
                       Red = "B",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 10,
                       Red = "B",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 11,
                       Red = "B",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 12,
                       Red = "B",
                       Broj = 6,
                       SalaId = 1
                   },

                   new Sjediste {
                       Id = 13,
                       Red = "C",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 14,
                       Red = "C",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 15,
                       Red = "C",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 16,
                       Red = "C",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 17,
                       Red = "C",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 18,
                       Red = "C",
                       Broj = 6,
                       SalaId = 1
                   },

                   new Sjediste {
                       Id = 19,
                       Red = "D",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 20,
                       Red = "D",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 21,
                       Red = "D",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 22,
                       Red = "D",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 23,
                       Red = "D",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 24,
                       Red = "D",
                       Broj = 6,
                       SalaId = 1
                   },

                   new Sjediste {
                       Id = 25,
                       Red = "E",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 26,
                       Red = "E",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 27,
                       Red = "E",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 28,
                       Red = "E",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 29,
                       Red = "E",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 30,
                       Red = "E",
                       Broj = 6,
                       SalaId = 1
                   },

                   new Sjediste {
                       Id = 31,
                       Red = "F",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 32,
                       Red = "F",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 33,
                       Red = "F",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 34,
                       Red = "F",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 35,
                       Red = "F",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 36,
                       Red = "F",
                       Broj = 6,
                       SalaId = 1
                   },

                   new Sjediste {
                       Id = 37,
                       Red = "G",
                       Broj = 1,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 38,
                       Red = "G",
                       Broj = 2,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 39,
                       Red = "G",
                       Broj = 3,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 40,
                       Red = "G",
                       Broj = 4,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 41,
                       Red = "G",
                       Broj = 5,
                       SalaId = 1
                   },
                   new Sjediste {
                       Id = 42,
                       Red = "G",
                       Broj = 6,
                       SalaId = 1
                   },


                   new Sjediste {
                       Id = 43,
                       Red = "A",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 44,
                       Red = "A",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 45,
                       Red = "A",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 46,
                       Red = "A",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 47,
                       Red = "A",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 48,
                       Red = "A",
                       Broj = 6,
                       SalaId = 2
                   },

                   new Sjediste {
                       Id = 49,
                       Red = "B",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 50,
                       Red = "B",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 51,
                       Red = "B",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 52,
                       Red = "B",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 53,
                       Red = "B",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 54,
                       Red = "B",
                       Broj = 6,
                       SalaId = 2
                   },

                   new Sjediste {
                       Id = 55,
                       Red = "C",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 56,
                       Red = "C",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 57,
                       Red = "C",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 58,
                       Red = "C",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 59,
                       Red = "C",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 60,
                       Red = "C",
                       Broj = 6,
                       SalaId = 2
                   },

                   new Sjediste {
                       Id = 61,
                       Red = "D",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 62,
                       Red = "D",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 63,
                       Red = "D",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 64,
                       Red = "D",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 65,
                       Red = "D",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 66,
                       Red = "D",
                       Broj = 6,
                       SalaId = 2
                   },

                   new Sjediste {
                       Id = 67,
                       Red = "E",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 68,
                       Red = "E",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 69,
                       Red = "E",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 70,
                       Red = "E",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 71,
                       Red = "E",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 72,
                       Red = "E",
                       Broj = 6,
                       SalaId = 2
                   },

                   new Sjediste {
                       Id = 73,
                       Red = "F",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 74,
                       Red = "F",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 75,
                       Red = "F",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 76,
                       Red = "F",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 77,
                       Red = "F",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 78,
                       Red = "F",
                       Broj = 6,
                       SalaId = 2
                   },

                   new Sjediste {
                       Id = 79,
                       Red = "G",
                       Broj = 1,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 80,
                       Red = "G",
                       Broj = 2,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 81,
                       Red = "G",
                       Broj = 3,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 82,
                       Red = "G",
                       Broj = 4,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 83,
                       Red = "G",
                       Broj = 5,
                       SalaId = 2
                   },
                   new Sjediste {
                       Id = 84,
                       Red = "G",
                       Broj = 6,
                       SalaId = 2
                   }
               );

            modelBuilder.Entity<Projekcija>()
               .HasData(
                    new Projekcija {
                        Id = 1,
                        FilmId = 1,
                        SalaId = 1,
                        Cijena = 7.5M,
                        Datum = datum,
                        VrijediOd = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 0, 0, 0),
                        VrijediDo = new DateTime(datum.AddDays(1).Year, datum.AddDays(1).Month, datum.AddDays(1).Day, 23, 59, 59),
                    },
                    new Projekcija {
                        Id = 2,
                        FilmId = 2,
                        SalaId = 2,
                        Cijena = 5.5M,
                        Datum = datum,
                        VrijediOd = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 0, 0, 0),
                        VrijediDo = new DateTime(datum.AddDays(1).Year, datum.AddDays(1).Month, datum.AddDays(1).Day, 23, 59, 59),
                    }
                );

            modelBuilder.Entity<ProjekcijaTermin>()
               .HasData(
                    new ProjekcijaTermin {
                        Id = 1,
                        ProjekcijaId = 1,
                        Termin = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 13, 30, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 2,
                        ProjekcijaId = 1,
                        Termin = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 18, 40, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 3,
                        ProjekcijaId = 1,
                        Termin = new DateTime(datum.AddDays(1).Year, datum.AddDays(1).Month, datum.AddDays(1).Day, 13, 30, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 4,
                        ProjekcijaId = 1,
                        Termin = new DateTime(datum.AddDays(1).Year, datum.AddDays(1).Month, datum.AddDays(1).Day, 18, 40, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 5,
                        ProjekcijaId = 2,
                        Termin = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 13, 30, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 6,
                        ProjekcijaId = 2,
                        Termin = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 18, 40, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 7,
                        ProjekcijaId = 2,
                        Termin = new DateTime(datum.AddDays(1).Year, datum.AddDays(1).Month, datum.AddDays(1).Day, 13, 30, 0)
                    },
                    new ProjekcijaTermin {
                        Id = 8,
                        ProjekcijaId = 2,
                        Termin = new DateTime(datum.AddDays(1).Year, datum.AddDays(1).Month, datum.AddDays(1).Day, 18, 40, 0)
                    }
                );

            modelBuilder.Entity<Dojam>()
               .HasData(
                    new Dojam {
                        Id = 1,
                        ProjekcijaId = 1,
                        KorisnikId = 4,
                        Ocjena = 5,
                        Tekst = "Odličan film, potpuno sam zadovoljan uslugama kina.",
                        Datum = datum
                    },
                    new Dojam {
                        Id = 2,
                        ProjekcijaId = 1,
                        KorisnikId = 6,
                        Ocjena = 4,
                        Tekst = "Kokice su bile preslane.",
                        Datum = datum
                    },
                    new Dojam {
                        Id = 3,
                        ProjekcijaId = 2,
                        KorisnikId = 6,
                        Ocjena = 5,
                        Datum = datum
                    }
                );

            modelBuilder.Entity<Rezervacija>()
               .HasData(
                    new Rezervacija {
                        Id = 1,
                        KorisnikId = 4,
                        BrojSjedista = 2,
                        Cijena = 15M,
                        Datum = datum.AddDays(1),
                        DatumProdano = datum.AddDays(1),
                        DatumProjekcije = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 13, 30, 0),
                        ProjekcijaTerminId = 1
                    },
                    new Rezervacija {
                        Id = 2,
                        KorisnikId = 6,
                        BrojSjedista = 1,
                        Cijena = 5.5M,
                        Datum = datum.AddDays(1),
                        DatumProjekcije = new DateTime(datum.AddDays(-1).Year, datum.AddDays(-1).Month, datum.AddDays(-1).Day, 13, 30, 0),
                        ProjekcijaTerminId = 5
                    }
                );

            modelBuilder.Entity<SjedisteRezervacija>()
               .HasData(
                    new SjedisteRezervacija {
                        Id=1,
                        SjedisteId = 20,
                        RezervacijaId = 1
                    },
                    new SjedisteRezervacija {
                        Id = 2,
                        SjedisteId = 21,
                        RezervacijaId = 1
                    },
                    new SjedisteRezervacija {
                        Id = 3,
                        SjedisteId = 48,
                        RezervacijaId = 2
                    }
                );

            modelBuilder.Entity<Prodaja>()
                .HasData(
                    new Prodaja {
                        Id = 1,
                        BrojRacuna = "1234abc-def56",
                        KorisnikId = 3,
                        Datum = datum,
                        RezervacijaId = 1
                    }
                );

            modelBuilder.Entity<ProdajaArtikal>()
                .HasData(
                    new ProdajaArtikal {
                        Id = 1,
                        Kolicina = 1,
                        ProdajaId = 1,
                        ArtikalId = 1
                    }
                );
        }
    }
}