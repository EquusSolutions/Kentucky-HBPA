namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Time");
            DropColumn("dbo.Events", "Title");
            DropColumn("dbo.Events", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Location", c => c.String());
            AddColumn("dbo.Events", "Title", c => c.String());
            AddColumn("dbo.Events", "Time", c => c.DateTime(nullable: false));
        }
    }
}
