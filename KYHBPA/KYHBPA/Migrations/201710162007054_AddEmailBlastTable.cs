namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailBlastTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailBlasts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        To = c.String(),
                        From = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        Attachment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documents", t => t.Attachment_Id)
                .Index(t => t.Attachment_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailBlasts", "Attachment_Id", "dbo.Documents");
            DropIndex("dbo.EmailBlasts", new[] { "Attachment_Id" });
            DropTable("dbo.EmailBlasts");
        }
    }
}
