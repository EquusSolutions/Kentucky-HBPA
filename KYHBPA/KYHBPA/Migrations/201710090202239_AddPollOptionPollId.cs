namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPollOptionPollId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PollOptions", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.PollOptions", new[] { "Poll_Id" });
            RenameColumn(table: "dbo.PollOptions", name: "Poll_Id", newName: "PollId");
            AlterColumn("dbo.PollOptions", "PollId", c => c.Int(nullable: false));
            CreateIndex("dbo.PollOptions", "PollId");
            AddForeignKey("dbo.PollOptions", "PollId", "dbo.Polls", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PollOptions", "PollId", "dbo.Polls");
            DropIndex("dbo.PollOptions", new[] { "PollId" });
            AlterColumn("dbo.PollOptions", "PollId", c => c.Int());
            RenameColumn(table: "dbo.PollOptions", name: "PollId", newName: "Poll_Id");
            CreateIndex("dbo.PollOptions", "Poll_Id");
            AddForeignKey("dbo.PollOptions", "Poll_Id", "dbo.Polls", "Id");
        }
    }
}
