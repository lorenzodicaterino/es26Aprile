using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione26Aprile.Models;

public partial class Esercitazione26AprileContext : DbContext
{
    public Esercitazione26AprileContext()
    {
    }

    public Esercitazione26AprileContext(DbContextOptions<Esercitazione26AprileContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Piatto> Piattos { get; set; }

    public virtual DbSet<Ristorante> Ristorantes { get; set; }

    public virtual DbSet<Utente> Utentes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-11\\SQLEXPRESS;Database=Esercitazione26Aprile;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Piatto>(entity =>
        {
            entity.HasKey(e => e.PiattoId).HasName("PK__piatto__BF1702A96BA0B00F");

            entity.ToTable("piatto");

            entity.Property(e => e.PiattoId).HasColumnName("piattoID");
            entity.Property(e => e.CodicePiatto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_piatto");
            entity.Property(e => e.DescrizionePiatto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("descrizione_piatto");
            entity.Property(e => e.NomePiatto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_piatto");
            entity.Property(e => e.PrezzoPiatto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("prezzo_piatto");
            entity.Property(e => e.RistoranteRif).HasColumnName("ristoranteRIF");

            entity.HasOne(d => d.RistoranteRifNavigation).WithMany(p => p.Piattos)
                .HasForeignKey(d => d.RistoranteRif)
                .HasConstraintName("FK__piatto__ristoran__45F365D3");
        });

        modelBuilder.Entity<Ristorante>(entity =>
        {
            entity.HasKey(e => e.RistoranteId).HasName("PK__ristoran__5EBF5F9AFF111FB7");

            entity.ToTable("ristorante");

            entity.Property(e => e.RistoranteId).HasColumnName("ristoranteID");
            entity.Property(e => e.CodiceRistorante)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_ristorante");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.NomeRistorante)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome_ristorante");
            entity.Property(e => e.OrarioApertura)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("orario_apertura");
            entity.Property(e => e.OrarioChiusura)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("orario_chiusura");
            entity.Property(e => e.Tipologia)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("tipologia");
        });

        modelBuilder.Entity<Utente>(entity =>
        {
            entity.HasKey(e => e.UtenteId).HasName("PK__utente__CA5C2253569B6F41");

            entity.ToTable("utente");

            entity.HasIndex(e => e.Email, "UQ__utente__AB6E61642DCE4D01").IsUnique();

            entity.Property(e => e.UtenteId).HasColumnName("utenteID");
            entity.Property(e => e.CodiceUtente)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("codice_utente");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nominativo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nominativo");
            entity.Property(e => e.Passsword)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("passsword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
