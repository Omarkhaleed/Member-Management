namespace FirstTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class z : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Members", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "image", c => c.Binary());
        }
    }
}
