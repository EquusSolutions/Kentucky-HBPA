namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageIDToCallToAction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CallToActions", "Image_Id", "dbo.Documents");
            DropIndex("dbo.CallToActions", new[] { "Image_Id" });
            RenameColumn(table: "dbo.CallToActions", name: "Image_Id", newName: "ImageId");
            AlterColumn("dbo.CallToActions", "ImageId", c => c.Int(nullable: false));
            CreateIndex("dbo.CallToActions", "ImageId");
            AddForeignKey("dbo.CallToActions", "ImageId", "dbo.Documents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CallToActions", "ImageId", "dbo.Documents");
            DropIndex("dbo.CallToActions", new[] { "ImageId" });
            AlterColumn("dbo.CallToActions", "ImageId", c => c.Int());
            RenameColumn(table: "dbo.CallToActions", name: "ImageId", newName: "Image_Id");
            CreateIndex("dbo.CallToActions", "Image_Id");
            AddForeignKey("dbo.CallToActions", "Image_Id", "dbo.Documents", "Id");
        }
    }
}
