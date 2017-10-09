namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVoterType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Votes", "Voter", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Votes", "Voter", c => c.Guid(nullable: false));
        }
    }
}
