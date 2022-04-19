namespace FirstTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "image");
        }
    }
}
