namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPollTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PollOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Votes = c.Int(nullable: false),
                        Title = c.String(),
                        Poll_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.Poll_Id)
                .Index(t => t.Poll_Id);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PollOptions", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.PollOptions", new[] { "Poll_Id" });
            DropTable("dbo.Polls");
            DropTable("dbo.PollOptions");
        }
    }
}
