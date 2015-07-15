namespace ProyectoISW2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datenonull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cursoes", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cursoes", "Fecha", c => c.DateTime());
        }
    }
}
