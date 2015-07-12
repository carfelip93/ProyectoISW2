namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LapicesId = c.Int(nullable: false),
                        CantidadLapices = c.Int(nullable: false),
                        PruebaId = c.Int(nullable: false),
                        CantidadPrueba = c.Int(nullable: false),
                        ManualId = c.Int(nullable: false),
                        CantidadManual = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lapices", t => t.LapicesId, cascadeDelete: true)
                .ForeignKey("dbo.Manuals", t => t.ManualId, cascadeDelete: true)
                .ForeignKey("dbo.Pruebas", t => t.PruebaId, cascadeDelete: true)
                .Index(t => t.LapicesId)
                .Index(t => t.PruebaId)
                .Index(t => t.ManualId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stocks", "PruebaId", "dbo.Pruebas");
            DropForeignKey("dbo.Stocks", "ManualId", "dbo.Manuals");
            DropForeignKey("dbo.Stocks", "LapicesId", "dbo.Lapices");
            DropIndex("dbo.Stocks", new[] { "ManualId" });
            DropIndex("dbo.Stocks", new[] { "PruebaId" });
            DropIndex("dbo.Stocks", new[] { "LapicesId" });
            DropTable("dbo.Stocks");
        }
    }
}
