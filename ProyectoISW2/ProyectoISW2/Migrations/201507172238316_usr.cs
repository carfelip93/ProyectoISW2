namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Nombre", c => c.String(nullable: false));
        }
    }
}
