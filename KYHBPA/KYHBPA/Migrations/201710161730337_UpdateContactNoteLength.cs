namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContactNoteLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Note", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Note", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
