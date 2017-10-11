namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCallToAction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CallToActions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(),
                        Headline = c.String(),
                        Summary = c.String(),
                        TypeOfAction = c.Int(nullable: false),
                        Image_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Documents", t => t.Image_Id)
                .Index(t => t.Image_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CallToActions", "Image_Id", "dbo.Documents");
            DropIndex("dbo.CallToActions", new[] { "Image_Id" });
            DropTable("dbo.CallToActions");
        }
    }
}
