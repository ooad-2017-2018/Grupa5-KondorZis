namespace SistemZaElektronskoGlasanjeASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClanKomisije",
                c => new
                    {
                        Jmbg = c.Long(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Password = c.String(),
                        Ovlasti = c.Boolean(nullable: false),
                        Id = c.String(),
                    })
                .PrimaryKey(t => t.Jmbg);
            
            CreateTable(
                "dbo.Glasac",
                c => new
                    {
                        Jmbg = c.Long(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        BrLicneKarte = c.String(),
                        MjestoStanovanja = c.String(),
                    })
                .PrimaryKey(t => t.Jmbg);
            
            CreateTable(
                "dbo.Kandidat",
                c => new
                    {
                        JMBG = c.Long(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Mjesto_stanovanja = c.String(),
                        N = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JMBG);
            
            CreateTable(
                "dbo.PSubjekat",
                c => new
                    {
                        ImeSubjekta = c.String(nullable: false, maxLength: 128),
                        Sjediste = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Predsjednik_JMBG = c.Long(),
                    })
                .PrimaryKey(t => t.ImeSubjekta)
                .ForeignKey("dbo.Kandidat", t => t.Predsjednik_JMBG)
                .Index(t => t.Predsjednik_JMBG);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PSubjekat", "Predsjednik_JMBG", "dbo.Kandidat");
            DropIndex("dbo.PSubjekat", new[] { "Predsjednik_JMBG" });
            DropTable("dbo.PSubjekat");
            DropTable("dbo.Kandidat");
            DropTable("dbo.Glasac");
            DropTable("dbo.ClanKomisije");
        }
    }
}
