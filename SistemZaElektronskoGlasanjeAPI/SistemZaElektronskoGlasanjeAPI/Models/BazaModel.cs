namespace SistemZaElektronskoGlasanjeAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BazaModel : DbContext
    {
        public BazaModel()
            : base("name=BazaModel")
        {
        }

        public virtual DbSet<GlasackiListic> GlasackiListics { get; set; }
        public virtual DbSet<Kandidat> Kandidats { get; set; }
        public virtual DbSet<PSubjekat> PSubjekats { get; set; }
        public virtual DbSet<StavkaListica> StavkaListicas { get; set; }
        public virtual DbSet<Utrka> Utrkas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlasackiListic>()
                .HasMany(e => e.StavkaListicas)
                .WithOptional(e => e.GlasackiListic)
                .HasForeignKey(e => e.GlasackiListic_Id);

            modelBuilder.Entity<Kandidat>()
                .HasMany(e => e.PSubjekats)
                .WithOptional(e => e.Kandidat)
                .HasForeignKey(e => e.Predsjednik_JMBG);

            modelBuilder.Entity<StavkaListica>()
                .HasMany(e => e.Kandidats)
                .WithOptional(e => e.StavkaListica)
                .HasForeignKey(e => e.StavkaListica_Id);

            modelBuilder.Entity<Utrka>()
                .HasMany(e => e.Kandidats)
                .WithOptional(e => e.Utrka)
                .HasForeignKey(e => e.Utrka_Naziv);

            modelBuilder.Entity<Utrka>()
                .HasMany(e => e.PSubjekats)
                .WithOptional(e => e.Utrka)
                .HasForeignKey(e => e.Utrka_Naziv);

            modelBuilder.Entity<Utrka>()
                .HasMany(e => e.StavkaListicas)
                .WithOptional(e => e.Utrka)
                .HasForeignKey(e => e.Utrka_Naziv);
        }
    }
}
