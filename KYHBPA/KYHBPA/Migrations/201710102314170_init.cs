namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PollOptions", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.PollOptions", new[] { "Poll_Id" });
            RenameColumn(table: "dbo.PollOptions", name: "Poll_Id", newName: "PollId");
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
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voter = c.String(),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Note", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.PollOptions", "PollId", c => c.Int(nullable: false));
            CreateIndex("dbo.PollOptions", "PollId");
            AddForeignKey("dbo.PollOptions", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PollOptions", "PollId", "dbo.Polls");
            DropForeignKey("dbo.CallToActions", "Image_Id", "dbo.Documents");
            DropIndex("dbo.PollOptions", new[] { "PollId" });
            DropIndex("dbo.CallToActions", new[] { "Image_Id" });
            AlterColumn("dbo.PollOptions", "PollId", c => c.Int());
            AlterColumn("dbo.Members", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "Note", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "LastName", c => c.String());
            AlterColumn("dbo.Contacts", "FirstName", c => c.String());
            DropTable("dbo.Votes");
            DropTable("dbo.CallToActions");
            RenameColumn(table: "dbo.PollOptions", name: "PollId", newName: "Poll_Id");
            CreateIndex("dbo.PollOptions", "Poll_Id");
            AddForeignKey("dbo.PollOptions", "Poll_Id", "dbo.Polls", "Id");
        }
    }
}
