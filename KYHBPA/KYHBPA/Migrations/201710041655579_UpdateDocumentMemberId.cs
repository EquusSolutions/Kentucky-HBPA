namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocumentMemberId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "MemberId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "MemberId", c => c.Int(nullable: false));
        }
    }
}
