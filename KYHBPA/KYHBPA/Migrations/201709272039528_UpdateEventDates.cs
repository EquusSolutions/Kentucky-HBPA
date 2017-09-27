namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEventDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "EndDate");
            DropColumn("dbo.Events", "StartDate");
        }
    }
}
