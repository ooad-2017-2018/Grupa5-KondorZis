using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    public class BazaContext : DbContext
    {
        public BazaContext() : base("Server=tcp:sarajevo.database.windows.net,1433;Initial Catalog=SahatKula;Persist Security Info=False;User ID=kondorzis;Password=Valter_brani_Sarajev0;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
        {
        }
        public DbSet<Kandidat> Kandidat { get; set; }
        public DbSet<ClanKomisije> ClanKomisije { get; set; }
        public DbSet<Glasac> Glasac { get; set; }
        public DbSet<PSubjekat> PSubjekat { get; set; }
        public DbSet<GlasackiListic> GlasackiListic { get; set; }
        public DbSet<GlasackoMjesto> GlasackoMjesto { get; set; }
        public DbSet<StavkaListica> StavkaListica { get; set; }
        public DbSet<Utrka> Utrka { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}