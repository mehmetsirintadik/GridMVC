namespace Mvc.Grid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personeller",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        Soyad = c.String(),
                        Yas = c.Int(nullable: false),
                        Ulke_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ulkeler", t => t.Ulke_id)
                .Index(t => t.Ulke_id);
            
            CreateTable(
                "dbo.Ulkeler",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personeller", "Ulke_id", "dbo.Ulkeler");
            DropIndex("dbo.Personeller", new[] { "Ulke_id" });
            DropTable("dbo.Ulkeler");
            DropTable("dbo.Personeller");
        }
    }
}
