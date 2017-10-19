namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureIdNews : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "Picture_Id", "dbo.Documents");
            DropIndex("dbo.News", new[] { "Picture_Id" });
            RenameColumn(table: "dbo.News", name: "Picture_Id", newName: "PictureId");
            AlterColumn("dbo.News", "PictureId", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "PictureId");
            AddForeignKey("dbo.News", "PictureId", "dbo.Documents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "PictureId", "dbo.Documents");
            DropIndex("dbo.News", new[] { "PictureId" });
            AlterColumn("dbo.News", "PictureId", c => c.Int());
            RenameColumn(table: "dbo.News", name: "PictureId", newName: "Picture_Id");
            CreateIndex("dbo.News", "Picture_Id");
            AddForeignKey("dbo.News", "Picture_Id", "dbo.Documents", "Id");
        }
    }
}
