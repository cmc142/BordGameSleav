namespace Boardgamesleeves.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class BGSModel : DbContext
    {
        public BGSModel()
            : base("name=BGSEntities")
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Bestiltvare> Bestiltvare { get; set; }
        public virtual DbSet<Braetspil> Braetspil { get; set; }
        public virtual DbSet<Faktura> Faktura { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Stoerrelse> Stoerrelse { get; set; }
        public virtual DbSet<Vare> Vare { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>()
                .Property(e => e.Brugernavn)
                .IsUnicode(false);

            modelBuilder.Entity<Administrator>()
                .Property(e => e.Adgangskode)
                .IsUnicode(false);

            modelBuilder.Entity<Bestiltvare>()
                .Property(e => e.Vareid)
                .IsUnicode(false);

            modelBuilder.Entity<Braetspil>()
                .Property(e => e.Spilnavn)
                .IsUnicode(false);

            modelBuilder.Entity<Braetspil>()
                .HasMany(e => e.Stoerrelse)
                .WithMany(e => e.Braetspil)
                .Map(m => m.ToTable("Forbindelsetilspil").MapLeftKey("Braetspilid").MapRightKey("Stoerrelseid"));

            modelBuilder.Entity<Faktura>()
                .HasMany(e => e.Bestiltvare)
                .WithRequired(e => e.Faktura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Fornavn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Efternavn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Bynavn)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Land)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Kunde>()
                .HasMany(e => e.Faktura)
                .WithRequired(e => e.Kunde)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stoerrelse>()
                .Property(e => e.StoerrelsesType)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Vareid)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Pris)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Kategori)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Beskrivelse)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .Property(e => e.Billedsti)
                .IsUnicode(false);

            modelBuilder.Entity<Vare>()
                .HasMany(e => e.Bestiltvare)
                .WithRequired(e => e.Vare)
                .WillCascadeOnDelete(false);
        }
    }
}
