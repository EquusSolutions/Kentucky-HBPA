namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBlogDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Posted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "Posted");
        }
    }
}
