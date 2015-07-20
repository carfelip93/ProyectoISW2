namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lst : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pruebas", "Stock_Id", c => c.Int());
            CreateIndex("dbo.Pruebas", "Stock_Id");
            AddForeignKey("dbo.Pruebas", "Stock_Id", "dbo.Stocks", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pruebas", "Stock_Id", "dbo.Stocks");
            DropIndex("dbo.Pruebas", new[] { "Stock_Id" });
            DropColumn("dbo.Pruebas", "Stock_Id");
        }
    }
}
