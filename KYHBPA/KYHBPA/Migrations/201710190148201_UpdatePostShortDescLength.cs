namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePostShortDescLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ShortDescription", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "ShortDescription", c => c.String());
        }
    }
}
