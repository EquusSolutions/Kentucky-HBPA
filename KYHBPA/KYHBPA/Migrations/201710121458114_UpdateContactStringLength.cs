namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContactStringLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Note", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Note", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false));
        }
    }
}
