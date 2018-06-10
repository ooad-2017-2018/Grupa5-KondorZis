namespace SistemZaElektronskoGlasanjeASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Druga : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GlasackiListic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StavkaListica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Utrka_Naziv = c.String(maxLength: 128),
                        GlasackiListic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utrka", t => t.Utrka_Naziv)
                .ForeignKey("dbo.GlasackiListic", t => t.GlasackiListic_Id)
                .Index(t => t.Utrka_Naziv)
                .Index(t => t.GlasackiListic_Id);
            
            CreateTable(
                "dbo.Utrka",
                c => new
                    {
                        Naziv = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Naziv);
            
            CreateTable(
                "dbo.GlasackoMjesto",
                c => new
                    {
                        LokacijaMjesta = c.String(nullable: false, maxLength: 128),
                        Utrka_Naziv = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LokacijaMjesta)
                .ForeignKey("dbo.Utrka", t => t.Utrka_Naziv)
                .Index(t => t.Utrka_Naziv);
            
            AddColumn("dbo.Glasac", "GlasackoMjesto_LokacijaMjesta", c => c.String(maxLength: 128));
            AddColumn("dbo.Kandidat", "StavkaListica_Id", c => c.Int());
            AddColumn("dbo.Kandidat", "Utrka_Naziv", c => c.String(maxLength: 128));
            AddColumn("dbo.PSubjekat", "Utrka_Naziv", c => c.String(maxLength: 128));
            CreateIndex("dbo.Glasac", "GlasackoMjesto_LokacijaMjesta");
            CreateIndex("dbo.Kandidat", "StavkaListica_Id");
            CreateIndex("dbo.Kandidat", "Utrka_Naziv");
            CreateIndex("dbo.PSubjekat", "Utrka_Naziv");
            AddForeignKey("dbo.Kandidat", "StavkaListica_Id", "dbo.StavkaListica", "Id");
            AddForeignKey("dbo.Kandidat", "Utrka_Naziv", "dbo.Utrka", "Naziv");
            AddForeignKey("dbo.Glasac", "GlasackoMjesto_LokacijaMjesta", "dbo.GlasackoMjesto", "LokacijaMjesta");
            AddForeignKey("dbo.PSubjekat", "Utrka_Naziv", "dbo.Utrka", "Naziv");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StavkaListica", "GlasackiListic_Id", "dbo.GlasackiListic");
            DropForeignKey("dbo.StavkaListica", "Utrka_Naziv", "dbo.Utrka");
            DropForeignKey("dbo.PSubjekat", "Utrka_Naziv", "dbo.Utrka");
            DropForeignKey("dbo.GlasackoMjesto", "Utrka_Naziv", "dbo.Utrka");
            DropForeignKey("dbo.Glasac", "GlasackoMjesto_LokacijaMjesta", "dbo.GlasackoMjesto");
            DropForeignKey("dbo.Kandidat", "Utrka_Naziv", "dbo.Utrka");
            DropForeignKey("dbo.Kandidat", "StavkaListica_Id", "dbo.StavkaListica");
            DropIndex("dbo.PSubjekat", new[] { "Utrka_Naziv" });
            DropIndex("dbo.GlasackoMjesto", new[] { "Utrka_Naziv" });
            DropIndex("dbo.Kandidat", new[] { "Utrka_Naziv" });
            DropIndex("dbo.Kandidat", new[] { "StavkaListica_Id" });
            DropIndex("dbo.StavkaListica", new[] { "GlasackiListic_Id" });
            DropIndex("dbo.StavkaListica", new[] { "Utrka_Naziv" });
            DropIndex("dbo.Glasac", new[] { "GlasackoMjesto_LokacijaMjesta" });
            DropColumn("dbo.PSubjekat", "Utrka_Naziv");
            DropColumn("dbo.Kandidat", "Utrka_Naziv");
            DropColumn("dbo.Kandidat", "StavkaListica_Id");
            DropColumn("dbo.Glasac", "GlasackoMjesto_LokacijaMjesta");
            DropTable("dbo.GlasackoMjesto");
            DropTable("dbo.Utrka");
            DropTable("dbo.StavkaListica");
            DropTable("dbo.GlasackiListic");
        }
    }
}
