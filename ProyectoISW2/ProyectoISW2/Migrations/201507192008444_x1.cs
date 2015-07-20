namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class x1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stocks", "LapicesId", "dbo.Lapices");
            DropForeignKey("dbo.Stocks", "ManualId", "dbo.Manuals");
            DropForeignKey("dbo.Stocks", "PruebaId", "dbo.Pruebas");
            DropForeignKey("dbo.Pruebas", "Stock_Id", "dbo.Stocks");
            DropIndex("dbo.Pruebas", new[] { "Stock_Id" });
            DropIndex("dbo.Stocks", new[] { "LapicesId" });
            DropIndex("dbo.Stocks", new[] { "PruebaId" });
            DropIndex("dbo.Stocks", new[] { "ManualId" });
            DropColumn("dbo.Pruebas", "Stock_Id");
            DropTable("dbo.Stocks");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pruebas", "Stock_Id", c => c.Int());
            CreateIndex("dbo.Stocks", "ManualId");
            CreateIndex("dbo.Stocks", "PruebaId");
            CreateIndex("dbo.Stocks", "LapicesId");
            CreateIndex("dbo.Pruebas", "Stock_Id");
            AddForeignKey("dbo.Pruebas", "Stock_Id", "dbo.Stocks", "Id");
            AddForeignKey("dbo.Stocks", "PruebaId", "dbo.Pruebas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Stocks", "ManualId", "dbo.Manuals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Stocks", "LapicesId", "dbo.Lapices", "Id", cascadeDelete: true);
        }
    }
}
