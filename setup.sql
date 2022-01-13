USE [master]
GO
/****** Object:  Database [180101]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE DATABASE [180101]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'180101', FILENAME = N'/var/opt/mssql/data/180101.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'180101_log', FILENAME = N'/var/opt/mssql/data/180101_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [180101] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [180101].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [180101] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [180101] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [180101] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [180101] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [180101] SET ARITHABORT OFF 
GO
ALTER DATABASE [180101] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [180101] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [180101] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [180101] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [180101] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [180101] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [180101] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [180101] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [180101] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [180101] SET  ENABLE_BROKER 
GO
ALTER DATABASE [180101] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [180101] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [180101] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [180101] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [180101] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [180101] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [180101] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [180101] SET RECOVERY FULL 
GO
ALTER DATABASE [180101] SET  MULTI_USER 
GO
ALTER DATABASE [180101] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [180101] SET DB_CHAINING OFF 
GO
ALTER DATABASE [180101] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [180101] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [180101] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'180101', N'ON'
GO
ALTER DATABASE [180101] SET QUERY_STORE = OFF
GO
USE [180101]
GO
/****** Object:  Table [dbo].[Anketa]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anketa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[Naslov] [nvarchar](250) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[ZakljucenoDatum] [datetime2](7) NULL,
 CONSTRAINT [PK_Anketa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnketaOdgovor]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnketaOdgovor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AnketaID] [int] NOT NULL,
	[Odgovor] [nvarchar](1000) NOT NULL,
	[RedniBroj] [int] NOT NULL,
	[UkupnoIzabrano] [int] NOT NULL,
 CONSTRAINT [PK_AnketaOdgovor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnketaOdgovorKorisnik]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnketaOdgovorKorisnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AnketaOdgovorID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_AnketaOdgovorKorisnik] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artikal]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artikal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[JedinicaMjereID] [int] NOT NULL,
	[Sifra] [nvarchar](20) NOT NULL,
	[Naziv] [nvarchar](250) NOT NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[Slika] [varbinary](max) NULL,
	[SlikaThumb] [varbinary](max) NULL,
 CONSTRAINT [PK_Artikal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dojam]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dojam](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjekcijaID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[Ocjena] [int] NOT NULL,
	[Tekst] [nvarchar](2000) NULL,
	[Datum] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Dojam] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Film]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Film](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naslov] [nvarchar](250) NOT NULL,
	[Trajanje] [int] NOT NULL,
	[GodinaSnimanja] [int] NOT NULL,
	[Sadrzaj] [nvarchar](2000) NULL,
	[VideoLink] [nvarchar](100) NULL,
	[ImdbLink] [nvarchar](100) NULL,
	[Plakat] [varbinary](max) NULL,
	[PlakatThumb] [varbinary](max) NULL,
	[RediteljID] [int] NOT NULL,
	[ZanrID] [int] NOT NULL,
 CONSTRAINT [PK_Film] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmGlumac]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmGlumac](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FilmID] [int] NOT NULL,
	[FilmskaLicnostID] [int] NOT NULL,
 CONSTRAINT [PK_FilmGlumac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmskaLicnost]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmskaLicnost](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [nvarchar](250) NOT NULL,
	[Prezime] [nvarchar](250) NOT NULL,
	[IsReziser] [bit] NOT NULL,
	[IsGlumac] [bit] NOT NULL,
 CONSTRAINT [PK_FilmskaLicnost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JedinicaMjere]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JedinicaMjere](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KratkiNaziv] [nvarchar](max) NOT NULL,
	[Naziv] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JedinicaMjere] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TipKorisnikaID] [int] NOT NULL,
	[KorisnickoIme] [nvarchar](250) NOT NULL,
	[LozinkaHash] [nvarchar](250) NOT NULL,
	[LozinkaSalt] [nvarchar](250) NOT NULL,
	[Ime] [nvarchar](250) NOT NULL,
	[Prezime] [nvarchar](250) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Spol] [nvarchar](10) NOT NULL,
	[DatumRodjenja] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Obavijest]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Obavijest](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[Naslov] [nvarchar](250) NOT NULL,
	[Tekst] [nvarchar](2000) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Obavijest] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prodaja]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodaja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BrojRacuna] [nvarchar](max) NOT NULL,
	[KorisnikId] [int] NULL,
	[Datum] [datetime2](7) NOT NULL,
	[RezervacijaId] [int] NULL,
 CONSTRAINT [PK_Prodaja] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProdajaArtikal]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProdajaArtikal](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProdajaID] [int] NOT NULL,
	[ArtikalID] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
 CONSTRAINT [PK_ProdajaArtikal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projekcija]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projekcija](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FilmID] [int] NOT NULL,
	[SalaID] [int] NOT NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[VrijediOd] [datetime2](7) NOT NULL,
	[VrijediDo] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Projekcija] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjekcijaKorisnik]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjekcijaKorisnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjekcijaID] [int] NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[DatumPosjete] [datetime2](7) NOT NULL,
	[DatumPosljednjePosjete] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProjekcijaKorisnik] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjekcijaTermin]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjekcijaTermin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjekcijaID] [int] NOT NULL,
	[Termin] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ProjekcijaTermin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rezervacija]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rezervacija](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KorisnikID] [int] NOT NULL,
	[BrojSjedista] [int] NOT NULL,
	[Cijena] [decimal](18, 2) NOT NULL,
	[Datum] [datetime2](7) NOT NULL,
	[DatumProjekcije] [datetime2](7) NOT NULL,
	[DatumProdano] [datetime2](7) NULL,
	[DatumOtkazano] [datetime2](7) NULL,
	[ProjekcijaTerminID] [int] NOT NULL,
 CONSTRAINT [PK_Rezervacija] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](250) NOT NULL,
	[BrojSjedista] [int] NOT NULL,
	[BrojSjedistaDuzina] [int] NOT NULL,
	[BrojSjedistaSirina] [int] NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sjediste]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sjediste](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Red] [nvarchar](1) NOT NULL,
	[Broj] [int] NOT NULL,
	[SalaID] [int] NOT NULL,
 CONSTRAINT [PK_Sjediste] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SjedisteRezervacija]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SjedisteRezervacija](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SjedisteID] [int] NOT NULL,
	[RezervacijaID] [int] NOT NULL,
 CONSTRAINT [PK_SjedisteRezervacija] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipKorisnika]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipKorisnika](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TipKorisnika] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zanr]    Script Date: 1/13/2022 9:48:31 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zanr](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [nvarchar](250) NOT NULL,
	[Opis] [nvarchar](2000) NULL,
 CONSTRAINT [PK_Zanr] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Anketa_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Anketa_KorisnikId] ON [dbo].[Anketa]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnketaOdgovor_AnketaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_AnketaOdgovor_AnketaId] ON [dbo].[AnketaOdgovor]
(
	[AnketaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnketaOdgovorKorisnikDodjela_AnketaOdgovorId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_AnketaOdgovorKorisnikDodjela_AnketaOdgovorId] ON [dbo].[AnketaOdgovorKorisnik]
(
	[AnketaOdgovorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AnketaOdgovorKorisnikDodjela_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_AnketaOdgovorKorisnikDodjela_KorisnikId] ON [dbo].[AnketaOdgovorKorisnik]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Artikal_JedinicaMjereId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Artikal_JedinicaMjereId] ON [dbo].[Artikal]
(
	[JedinicaMjereID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Dojam_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Dojam_KorisnikId] ON [dbo].[Dojam]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Dojam_ProjekcijaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Dojam_ProjekcijaId] ON [dbo].[Dojam]
(
	[ProjekcijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Film_RediteljId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Film_RediteljId] ON [dbo].[Film]
(
	[RediteljID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Film_ZanrId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Film_ZanrId] ON [dbo].[Film]
(
	[ZanrID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FilmGlumacDodjela_FilmId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_FilmGlumacDodjela_FilmId] ON [dbo].[FilmGlumac]
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FilmGlumacDodjela_FilmskaLicnostId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_FilmGlumacDodjela_FilmskaLicnostId] ON [dbo].[FilmGlumac]
(
	[FilmskaLicnostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Korisnik_TipKorisnikaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Korisnik_TipKorisnikaId] ON [dbo].[Korisnik]
(
	[TipKorisnikaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Obavijest_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Obavijest_KorisnikId] ON [dbo].[Obavijest]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prodaja_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Prodaja_KorisnikId] ON [dbo].[Prodaja]
(
	[KorisnikId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prodaja_RezervacijaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Prodaja_RezervacijaId] ON [dbo].[Prodaja]
(
	[RezervacijaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProdajaArtikalDodjela_ArtikalId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProdajaArtikalDodjela_ArtikalId] ON [dbo].[ProdajaArtikal]
(
	[ArtikalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProdajaArtikalDodjela_ProdajaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProdajaArtikalDodjela_ProdajaId] ON [dbo].[ProdajaArtikal]
(
	[ProdajaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projekcija_FilmId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Projekcija_FilmId] ON [dbo].[Projekcija]
(
	[FilmID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Projekcija_SalaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Projekcija_SalaId] ON [dbo].[Projekcija]
(
	[SalaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjekcijaKorisnikDodjela_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjekcijaKorisnikDodjela_KorisnikId] ON [dbo].[ProjekcijaKorisnik]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjekcijaKorisnikDodjela_ProjekcijaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjekcijaKorisnikDodjela_ProjekcijaId] ON [dbo].[ProjekcijaKorisnik]
(
	[ProjekcijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProjekcijaTermin_ProjekcijaId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProjekcijaTermin_ProjekcijaId] ON [dbo].[ProjekcijaTermin]
(
	[ProjekcijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rezervacija_KorisnikId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Rezervacija_KorisnikId] ON [dbo].[Rezervacija]
(
	[KorisnikID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Rezervacija_ProjekcijaTerminId]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Rezervacija_ProjekcijaTerminId] ON [dbo].[Rezervacija]
(
	[ProjekcijaTerminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Sjediste_SalaID]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_Sjediste_SalaID] ON [dbo].[Sjediste]
(
	[SalaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SjedisteRezervacija_RezervacijaID]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_SjedisteRezervacija_RezervacijaID] ON [dbo].[SjedisteRezervacija]
(
	[RezervacijaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SjedisteRezervacija_SjedisteID]    Script Date: 1/13/2022 9:48:31 AM ******/
CREATE NONCLUSTERED INDEX [IX_SjedisteRezervacija_SjedisteID] ON [dbo].[SjedisteRezervacija]
(
	[SjedisteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Anketa]  WITH CHECK ADD  CONSTRAINT [FK_Anketa_Korisnik_KorisnikId] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Anketa] CHECK CONSTRAINT [FK_Anketa_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[AnketaOdgovor]  WITH CHECK ADD  CONSTRAINT [FK_AnketaOdgovor_Anketa_AnketaId] FOREIGN KEY([AnketaID])
REFERENCES [dbo].[Anketa] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnketaOdgovor] CHECK CONSTRAINT [FK_AnketaOdgovor_Anketa_AnketaId]
GO
ALTER TABLE [dbo].[AnketaOdgovorKorisnik]  WITH CHECK ADD  CONSTRAINT [FK_AnketaOdgovorKorisnikDodjela_AnketaOdgovor_AnketaOdgovorId] FOREIGN KEY([AnketaOdgovorID])
REFERENCES [dbo].[AnketaOdgovor] ([ID])
GO
ALTER TABLE [dbo].[AnketaOdgovorKorisnik] CHECK CONSTRAINT [FK_AnketaOdgovorKorisnikDodjela_AnketaOdgovor_AnketaOdgovorId]
GO
ALTER TABLE [dbo].[AnketaOdgovorKorisnik]  WITH CHECK ADD  CONSTRAINT [FK_AnketaOdgovorKorisnikDodjela_Korisnik_KorisnikId] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AnketaOdgovorKorisnik] CHECK CONSTRAINT [FK_AnketaOdgovorKorisnikDodjela_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Artikal]  WITH CHECK ADD  CONSTRAINT [FK_Artikal_JedinicaMjere_JedinicaMjereId] FOREIGN KEY([JedinicaMjereID])
REFERENCES [dbo].[JedinicaMjere] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Artikal] CHECK CONSTRAINT [FK_Artikal_JedinicaMjere_JedinicaMjereId]
GO
ALTER TABLE [dbo].[Dojam]  WITH CHECK ADD  CONSTRAINT [FK_Dojam_Korisnik_KorisnikId] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dojam] CHECK CONSTRAINT [FK_Dojam_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Dojam]  WITH CHECK ADD  CONSTRAINT [FK_Dojam_Projekcija_ProjekcijaId] FOREIGN KEY([ProjekcijaID])
REFERENCES [dbo].[Projekcija] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dojam] CHECK CONSTRAINT [FK_Dojam_Projekcija_ProjekcijaId]
GO
ALTER TABLE [dbo].[Film]  WITH CHECK ADD  CONSTRAINT [FK_Film_FilmskaLicnost_RediteljId] FOREIGN KEY([RediteljID])
REFERENCES [dbo].[FilmskaLicnost] ([ID])
GO
ALTER TABLE [dbo].[Film] CHECK CONSTRAINT [FK_Film_FilmskaLicnost_RediteljId]
GO
ALTER TABLE [dbo].[Film]  WITH CHECK ADD  CONSTRAINT [FK_Film_Zanr_ZanrId] FOREIGN KEY([ZanrID])
REFERENCES [dbo].[Zanr] ([ID])
GO
ALTER TABLE [dbo].[Film] CHECK CONSTRAINT [FK_Film_Zanr_ZanrId]
GO
ALTER TABLE [dbo].[FilmGlumac]  WITH CHECK ADD  CONSTRAINT [FK_FilmGlumacDodjela_Film_FilmId] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmGlumac] CHECK CONSTRAINT [FK_FilmGlumacDodjela_Film_FilmId]
GO
ALTER TABLE [dbo].[FilmGlumac]  WITH CHECK ADD  CONSTRAINT [FK_FilmGlumacDodjela_FilmskaLicnost_FilmskaLicnostId] FOREIGN KEY([FilmskaLicnostID])
REFERENCES [dbo].[FilmskaLicnost] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmGlumac] CHECK CONSTRAINT [FK_FilmGlumacDodjela_FilmskaLicnost_FilmskaLicnostId]
GO
ALTER TABLE [dbo].[Korisnik]  WITH CHECK ADD  CONSTRAINT [FK_Korisnik_TipKorisnika] FOREIGN KEY([TipKorisnikaID])
REFERENCES [dbo].[TipKorisnika] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Korisnik] CHECK CONSTRAINT [FK_Korisnik_TipKorisnika]
GO
ALTER TABLE [dbo].[Obavijest]  WITH CHECK ADD  CONSTRAINT [FK_Obavijest_Korisnik_KorisnikId] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Obavijest] CHECK CONSTRAINT [FK_Obavijest_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Prodaja]  WITH CHECK ADD  CONSTRAINT [FK_Prodaja_Korisnik_KorisnikId] FOREIGN KEY([KorisnikId])
REFERENCES [dbo].[Korisnik] ([ID])
GO
ALTER TABLE [dbo].[Prodaja] CHECK CONSTRAINT [FK_Prodaja_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Prodaja]  WITH CHECK ADD  CONSTRAINT [FK_Prodaja_Rezervacija] FOREIGN KEY([RezervacijaId])
REFERENCES [dbo].[Rezervacija] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prodaja] CHECK CONSTRAINT [FK_Prodaja_Rezervacija]
GO
ALTER TABLE [dbo].[ProdajaArtikal]  WITH CHECK ADD  CONSTRAINT [FK_ProdajaArtikalDodjela_Artikal_ArtikalId] FOREIGN KEY([ArtikalID])
REFERENCES [dbo].[Artikal] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProdajaArtikal] CHECK CONSTRAINT [FK_ProdajaArtikalDodjela_Artikal_ArtikalId]
GO
ALTER TABLE [dbo].[ProdajaArtikal]  WITH CHECK ADD  CONSTRAINT [FK_ProdajaArtikalDodjela_Prodaja_ProdajaId] FOREIGN KEY([ProdajaID])
REFERENCES [dbo].[Prodaja] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProdajaArtikal] CHECK CONSTRAINT [FK_ProdajaArtikalDodjela_Prodaja_ProdajaId]
GO
ALTER TABLE [dbo].[Projekcija]  WITH CHECK ADD  CONSTRAINT [FK_Projekcija_Film_FilmId] FOREIGN KEY([FilmID])
REFERENCES [dbo].[Film] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projekcija] CHECK CONSTRAINT [FK_Projekcija_Film_FilmId]
GO
ALTER TABLE [dbo].[Projekcija]  WITH CHECK ADD  CONSTRAINT [FK_Projekcija_Sala_SalaId] FOREIGN KEY([SalaID])
REFERENCES [dbo].[Sala] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Projekcija] CHECK CONSTRAINT [FK_Projekcija_Sala_SalaId]
GO
ALTER TABLE [dbo].[ProjekcijaKorisnik]  WITH CHECK ADD  CONSTRAINT [FK_ProjekcijaKorisnikDodjela_Korisnik_KorisnikId] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjekcijaKorisnik] CHECK CONSTRAINT [FK_ProjekcijaKorisnikDodjela_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[ProjekcijaKorisnik]  WITH CHECK ADD  CONSTRAINT [FK_ProjekcijaKorisnikDodjela_Projekcija_ProjekcijaId] FOREIGN KEY([ProjekcijaID])
REFERENCES [dbo].[Projekcija] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjekcijaKorisnik] CHECK CONSTRAINT [FK_ProjekcijaKorisnikDodjela_Projekcija_ProjekcijaId]
GO
ALTER TABLE [dbo].[ProjekcijaTermin]  WITH CHECK ADD  CONSTRAINT [FK_ProjekcijaTermin_Projekcija_ProjekcijaId] FOREIGN KEY([ProjekcijaID])
REFERENCES [dbo].[Projekcija] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProjekcijaTermin] CHECK CONSTRAINT [FK_ProjekcijaTermin_Projekcija_ProjekcijaId]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_Rezervacija_Korisnik_KorisnikId] FOREIGN KEY([KorisnikID])
REFERENCES [dbo].[Korisnik] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_Rezervacija_Korisnik_KorisnikId]
GO
ALTER TABLE [dbo].[Rezervacija]  WITH CHECK ADD  CONSTRAINT [FK_Rezervacija_ProjekcijaTermin_ProjekcijaTerminId] FOREIGN KEY([ProjekcijaTerminID])
REFERENCES [dbo].[ProjekcijaTermin] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rezervacija] CHECK CONSTRAINT [FK_Rezervacija_ProjekcijaTermin_ProjekcijaTerminId]
GO
ALTER TABLE [dbo].[Sjediste]  WITH CHECK ADD  CONSTRAINT [FK_Sjediste_Sala] FOREIGN KEY([SalaID])
REFERENCES [dbo].[Sala] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sjediste] CHECK CONSTRAINT [FK_Sjediste_Sala]
GO
ALTER TABLE [dbo].[SjedisteRezervacija]  WITH CHECK ADD  CONSTRAINT [FK_SjedisteRezervacija_Rezervacija] FOREIGN KEY([RezervacijaID])
REFERENCES [dbo].[Rezervacija] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SjedisteRezervacija] CHECK CONSTRAINT [FK_SjedisteRezervacija_Rezervacija]
GO
ALTER TABLE [dbo].[SjedisteRezervacija]  WITH CHECK ADD  CONSTRAINT [FK_SjedisteRezervacija_Sjediste] FOREIGN KEY([SjedisteID])
REFERENCES [dbo].[Sjediste] ([ID])
GO
ALTER TABLE [dbo].[SjedisteRezervacija] CHECK CONSTRAINT [FK_SjedisteRezervacija_Sjediste]
GO
USE [master]
GO
ALTER DATABASE [180101] SET  READ_WRITE 
GO
