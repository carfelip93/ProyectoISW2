namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class val : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cursoes", "Ot", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Manuals", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Manuals", "Seccion", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Proyectors", "Modelo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Proyectors", "Marca", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Proyectors", "Asignacion", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Pruebas", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Pruebas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Proyectors", "Asignacion", c => c.String(nullable: false));
            AlterColumn("dbo.Proyectors", "Marca", c => c.String(nullable: false));
            AlterColumn("dbo.Proyectors", "Modelo", c => c.String(nullable: false));
            AlterColumn("dbo.Manuals", "Seccion", c => c.String(nullable: false));
            AlterColumn("dbo.Manuals", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Cursoes", "Ot", c => c.String(nullable: false));
        }
    }
}
