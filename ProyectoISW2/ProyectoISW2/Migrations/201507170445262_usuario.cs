namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "User", c => c.String(nullable: false));
            AddColumn("dbo.Usuarios", "Apellido", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "Apellido");
            DropColumn("dbo.Usuarios", "User");
        }
    }
}
