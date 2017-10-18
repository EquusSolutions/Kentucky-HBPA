namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToCallToActionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CallToActions", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CallToActions", "Date");
        }
    }
}
