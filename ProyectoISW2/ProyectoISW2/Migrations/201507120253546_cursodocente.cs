namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cursodocente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursoes", "Docente", c => c.String(nullable: false));
            AlterColumn("dbo.Cursoes", "Ot", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cursoes", "Ot", c => c.Int(nullable: false));
            DropColumn("dbo.Cursoes", "Docente");
        }
    }
}
