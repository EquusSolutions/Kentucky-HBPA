namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDocumentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Discriminator", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "UploadDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "UploadDate");
            DropColumn("dbo.Documents", "Discriminator");
        }
    }
}
