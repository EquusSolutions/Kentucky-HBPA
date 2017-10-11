namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberDoBNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "MemberId", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Documents", "MemberId", c => c.String());
        }
    }
}
