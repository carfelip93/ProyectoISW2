namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ot = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Ubicacion = c.String(nullable: false),
                        LapicesId = c.Int(nullable: false),
                        CantidadLapices = c.Int(nullable: false),
                        PruebaId = c.Int(nullable: false),
                        CantidadPrueba = c.Int(nullable: false),
                        ManualId = c.Int(nullable: false),
                        CantidadManual = c.Int(nullable: false),
                        ProyectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lapices", t => t.LapicesId, cascadeDelete: true)
                .ForeignKey("dbo.Manuals", t => t.ManualId, cascadeDelete: true)
                .ForeignKey("dbo.Proyectors", t => t.ProyectorId, cascadeDelete: true)
                .ForeignKey("dbo.Pruebas", t => t.PruebaId, cascadeDelete: true)
                .Index(t => t.LapicesId)
                .Index(t => t.PruebaId)
                .Index(t => t.ManualId)
                .Index(t => t.ProyectorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursoes", "PruebaId", "dbo.Pruebas");
            DropForeignKey("dbo.Cursoes", "ProyectorId", "dbo.Proyectors");
            DropForeignKey("dbo.Cursoes", "ManualId", "dbo.Manuals");
            DropForeignKey("dbo.Cursoes", "LapicesId", "dbo.Lapices");
            DropIndex("dbo.Cursoes", new[] { "ProyectorId" });
            DropIndex("dbo.Cursoes", new[] { "ManualId" });
            DropIndex("dbo.Cursoes", new[] { "PruebaId" });
            DropIndex("dbo.Cursoes", new[] { "LapicesId" });
            DropTable("dbo.Cursoes");
        }
    }
}
