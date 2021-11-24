﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Pelikula.DAO.Model
{
    public partial class RS2_PelikulaContext : DbContext
    {
        public RS2_PelikulaContext()
        {
        }

        public RS2_PelikulaContext(DbContextOptions<RS2_PelikulaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anketa> Anketa { get; set; }
        public virtual DbSet<AnketaOdgovor> AnketaOdgovor { get; set; }
        public virtual DbSet<AnketaOdgovorKorisnik> AnketaOdgovorKorisnik { get; set; }
        public virtual DbSet<Artikal> Artikal { get; set; }
        public virtual DbSet<Dojam> Dojam { get; set; }
        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmGlumac> FilmGlumac { get; set; }
        public virtual DbSet<FilmskaLicnost> FilmskaLicnost { get; set; }
        public virtual DbSet<JedinicaMjere> JedinicaMjere { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Obavijest> Obavijest { get; set; }
        public virtual DbSet<Prodaja> Prodaja { get; set; }
        public virtual DbSet<ProdajaArtikal> ProdajaArtikal { get; set; }
        public virtual DbSet<ProdajaRezervacija> ProdajaRezervacija { get; set; }
        public virtual DbSet<Projekcija> Projekcija { get; set; }
        public virtual DbSet<ProjekcijaKorisnik> ProjekcijaKorisnik { get; set; }
        public virtual DbSet<ProjekcijaTermin> ProjekcijaTermin { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }
        public virtual DbSet<Sala> Sala { get; set; }
        public virtual DbSet<Sjediste> Sjediste { get; set; }
        public virtual DbSet<SjedisteRezervacija> SjedisteRezervacija { get; set; }
        public virtual DbSet<TipKorisnika> TipKorisnika { get; set; }
        public virtual DbSet<Zanr> Zanr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RS2_Pelikula;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anketa>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_Anketa_KorisnikId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naslov).HasMaxLength(250);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Anketa)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Anketa_Korisnik_KorisnikId");
            });

            modelBuilder.Entity<AnketaOdgovor>(entity =>
            {
                entity.HasIndex(e => e.AnketaId)
                    .HasName("IX_AnketaOdgovor_AnketaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnketaId).HasColumnName("AnketaID");

                entity.Property(e => e.Odgovor).HasMaxLength(1000);

                entity.HasOne(d => d.Anketa)
                    .WithMany(p => p.AnketaOdgovor)
                    .HasForeignKey(d => d.AnketaId)
                    .HasConstraintName("FK_AnketaOdgovor_Anketa_AnketaId");
            });

            modelBuilder.Entity<AnketaOdgovorKorisnik>(entity =>
            {
                entity.HasIndex(e => e.AnketaOdgovorId)
                    .HasName("IX_AnketaOdgovorKorisnikDodjela_AnketaOdgovorId");

                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_AnketaOdgovorKorisnikDodjela_KorisnikId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AnketaOdgovorId).HasColumnName("AnketaOdgovorID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.HasOne(d => d.AnketaOdgovor)
                    .WithMany(p => p.AnketaOdgovorKorisnik)
                    .HasForeignKey(d => d.AnketaOdgovorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnketaOdgovorKorisnikDodjela_AnketaOdgovor_AnketaOdgovorId");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.AnketaOdgovorKorisnik)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_AnketaOdgovorKorisnikDodjela_Korisnik_KorisnikId");
            });

            modelBuilder.Entity<Artikal>(entity =>
            {
                entity.HasIndex(e => e.JedinicaMjereId)
                    .HasName("IX_Artikal_JedinicaMjereId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JedinicaMjereId).HasColumnName("JedinicaMjereID");

                entity.Property(e => e.Naziv).HasMaxLength(250);

                entity.Property(e => e.Sifra).HasMaxLength(20);

                entity.HasOne(d => d.JedinicaMjere)
                    .WithMany(p => p.Artikal)
                    .HasForeignKey(d => d.JedinicaMjereId)
                    .HasConstraintName("FK_Artikal_JedinicaMjere_JedinicaMjereId");
            });

            modelBuilder.Entity<Dojam>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_Dojam_KorisnikId");

                entity.HasIndex(e => e.ProjekcijaId)
                    .HasName("IX_Dojam_ProjekcijaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.ProjekcijaId).HasColumnName("ProjekcijaID");

                entity.Property(e => e.Tekst).HasMaxLength(2000);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Dojam)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Dojam_Korisnik_KorisnikId");

                entity.HasOne(d => d.Projekcija)
                    .WithMany(p => p.Dojam)
                    .HasForeignKey(d => d.ProjekcijaId)
                    .HasConstraintName("FK_Dojam_Projekcija_ProjekcijaId");
            });

            modelBuilder.Entity<Film>(entity =>
            {
                entity.HasIndex(e => e.RediteljId)
                    .HasName("IX_Film_RediteljId");

                entity.HasIndex(e => e.ZanrId)
                    .HasName("IX_Film_ZanrId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImdbLink).HasMaxLength(100);

                entity.Property(e => e.Naslov).HasMaxLength(250);

                entity.Property(e => e.RediteljId).HasColumnName("RediteljID");

                entity.Property(e => e.Sadrzaj).HasMaxLength(2000);

                entity.Property(e => e.VideoLink).HasMaxLength(100);

                entity.Property(e => e.ZanrId).HasColumnName("ZanrID");

                entity.HasOne(d => d.Reditelj)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.RediteljId)
                    .HasConstraintName("FK_Film_FilmskaLicnost_RediteljId");

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Film)
                    .HasForeignKey(d => d.ZanrId)
                    .HasConstraintName("FK_Film_Zanr_ZanrId");
            });

            modelBuilder.Entity<FilmGlumac>(entity =>
            {
                entity.HasIndex(e => e.FilmId)
                    .HasName("IX_FilmGlumacDodjela_FilmId");

                entity.HasIndex(e => e.FilmskaLicnostId)
                    .HasName("IX_FilmGlumacDodjela_FilmskaLicnostId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.FilmskaLicnostId).HasColumnName("FilmskaLicnostID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmGlumac)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_FilmGlumacDodjela_Film_FilmId");

                entity.HasOne(d => d.FilmskaLicnost)
                    .WithMany(p => p.FilmGlumac)
                    .HasForeignKey(d => d.FilmskaLicnostId)
                    .HasConstraintName("FK_FilmGlumacDodjela_FilmskaLicnost_FilmskaLicnostId");
            });

            modelBuilder.Entity<FilmskaLicnost>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ime).HasMaxLength(250);

                entity.Property(e => e.Prezime).HasMaxLength(250);
            });

            modelBuilder.Entity<JedinicaMjere>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasIndex(e => e.TipKorisnikaId)
                    .HasName("IX_Korisnik_TipKorisnikaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Ime).HasMaxLength(250);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(250);

                entity.Property(e => e.LozinkaHash).HasMaxLength(250);

                entity.Property(e => e.LozinkaSalt).HasMaxLength(250);

                entity.Property(e => e.Prezime).HasMaxLength(250);

                entity.Property(e => e.Spol).HasMaxLength(10);

                entity.Property(e => e.TipKorisnikaId).HasColumnName("TipKorisnikaID");

                entity.HasOne(d => d.TipKorisnika)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.TipKorisnikaId)
                    .HasConstraintName("FK_Korisnik_TipKorisnika_TipKorisnikaId");
            });

            modelBuilder.Entity<Obavijest>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_Obavijest_KorisnikId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Naslov).HasMaxLength(250);

                entity.Property(e => e.Tekst).HasMaxLength(2000);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Obavijest)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Obavijest_Korisnik_KorisnikId");
            });

            modelBuilder.Entity<Prodaja>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Popust).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Porez).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Prodaja)
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<ProdajaArtikal>(entity =>
            {
                entity.HasIndex(e => e.ArtikalId)
                    .HasName("IX_ProdajaArtikalDodjela_ArtikalId");

                entity.HasIndex(e => e.ProdajaId)
                    .HasName("IX_ProdajaArtikalDodjela_ProdajaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArtikalId).HasColumnName("ArtikalID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProdajaId).HasColumnName("ProdajaID");

                entity.HasOne(d => d.Artikal)
                    .WithMany(p => p.ProdajaArtikal)
                    .HasForeignKey(d => d.ArtikalId)
                    .HasConstraintName("FK_ProdajaArtikalDodjela_Artikal_ArtikalId");

                entity.HasOne(d => d.Prodaja)
                    .WithMany(p => p.ProdajaArtikal)
                    .HasForeignKey(d => d.ProdajaId)
                    .HasConstraintName("FK_ProdajaArtikalDodjela_Prodaja_ProdajaId");
            });

            modelBuilder.Entity<ProdajaRezervacija>(entity =>
            {
                entity.HasIndex(e => e.ProdajaId)
                    .HasName("IX_ProdajaRezervacijaDodjela_ProdajaId");

                entity.HasIndex(e => e.RezervacijaId)
                    .HasName("IX_ProdajaRezervacijaDodjela_RezervacijaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProdajaId).HasColumnName("ProdajaID");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.HasOne(d => d.Prodaja)
                    .WithMany(p => p.ProdajaRezervacija)
                    .HasForeignKey(d => d.ProdajaId)
                    .HasConstraintName("FK_ProdajaRezervacijaDodjela_Prodaja_ProdajaId");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.ProdajaRezervacija)
                    .HasForeignKey(d => d.RezervacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProdajaRezervacijaDodjela_Rezervacija_RezervacijaId");
            });

            modelBuilder.Entity<Projekcija>(entity =>
            {
                entity.HasIndex(e => e.FilmId)
                    .HasName("IX_Projekcija_FilmId");

                entity.HasIndex(e => e.SalaId)
                    .HasName("IX_Projekcija_SalaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FilmId).HasColumnName("FilmID");

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Projekcija)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("FK_Projekcija_Film_FilmId");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Projekcija)
                    .HasForeignKey(d => d.SalaId)
                    .HasConstraintName("FK_Projekcija_Sala_SalaId");
            });

            modelBuilder.Entity<ProjekcijaKorisnik>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_ProjekcijaKorisnikDodjela_KorisnikId");

                entity.HasIndex(e => e.ProjekcijaId)
                    .HasName("IX_ProjekcijaKorisnikDodjela_ProjekcijaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.ProjekcijaId).HasColumnName("ProjekcijaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.ProjekcijaKorisnik)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_ProjekcijaKorisnikDodjela_Korisnik_KorisnikId");

                entity.HasOne(d => d.Projekcija)
                    .WithMany(p => p.ProjekcijaKorisnik)
                    .HasForeignKey(d => d.ProjekcijaId)
                    .HasConstraintName("FK_ProjekcijaKorisnikDodjela_Projekcija_ProjekcijaId");
            });

            modelBuilder.Entity<ProjekcijaTermin>(entity =>
            {
                entity.HasIndex(e => e.ProjekcijaId)
                    .HasName("IX_ProjekcijaTermin_ProjekcijaId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProjekcijaId).HasColumnName("ProjekcijaID");

                entity.HasOne(d => d.Projekcija)
                    .WithMany(p => p.ProjekcijaTermin)
                    .HasForeignKey(d => d.ProjekcijaId)
                    .HasConstraintName("FK_ProjekcijaTermin_Projekcija_ProjekcijaId");
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId)
                    .HasName("IX_Rezervacija_KorisnikId");

                entity.HasIndex(e => e.ProjekcijaTerminId)
                    .HasName("IX_Rezervacija_ProjekcijaTerminId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.ProjekcijaTerminId).HasColumnName("ProjekcijaTerminID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KorisnikId)
                    .HasConstraintName("FK_Rezervacija_Korisnik_KorisnikId");

                entity.HasOne(d => d.ProjekcijaTermin)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.ProjekcijaTerminId)
                    .HasConstraintName("FK_Rezervacija_ProjekcijaTermin_ProjekcijaTerminId");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).HasMaxLength(250);
            });

            modelBuilder.Entity<Sjediste>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Red).HasMaxLength(1);

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Sjediste)
                    .HasForeignKey(d => d.SalaId)
                    .HasConstraintName("FK_Sjediste_Sala");
            });

            modelBuilder.Entity<SjedisteRezervacija>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProjekcijaTerminId).HasColumnName("ProjekcijaTerminID");

                entity.Property(e => e.RezervacijaId).HasColumnName("RezervacijaID");

                entity.Property(e => e.SjedisteId).HasColumnName("SjedisteID");

                entity.HasOne(d => d.ProjekcijaTermin)
                    .WithMany(p => p.SjedisteRezervacija)
                    .HasForeignKey(d => d.ProjekcijaTerminId)
                    .HasConstraintName("FK_SjedisteRezervacija_ProjekcijaTermin");

                entity.HasOne(d => d.Rezervacija)
                    .WithMany(p => p.SjedisteRezervacija)
                    .HasForeignKey(d => d.RezervacijaId)
                    .HasConstraintName("FK_SjedisteRezervacija_Rezervacija");

                entity.HasOne(d => d.Sjediste)
                    .WithMany(p => p.SjedisteRezervacija)
                    .HasForeignKey(d => d.SjedisteId)
                    .HasConstraintName("FK_SjedisteRezervacija_Sjediste");
            });

            modelBuilder.Entity<TipKorisnika>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).HasMaxLength(250);
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Naziv).HasMaxLength(250);

                entity.Property(e => e.Opis).HasMaxLength(2000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}