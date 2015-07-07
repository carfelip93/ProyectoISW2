namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crudsrestantes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Seccion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proyectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Modelo = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        Asignacion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pruebas", "Seccion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pruebas", "Seccion");
            DropTable("dbo.Proyectors");
            DropTable("dbo.Manuals");
        }
    }
}
