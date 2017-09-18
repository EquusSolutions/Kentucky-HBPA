namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        FileBytes = c.Binary(),
                        ContentLength = c.Int(nullable: false),
                        ContentType = c.String(),
                        FileName = c.String(),
                        UploadedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
