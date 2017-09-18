namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMinuteTypeToMinuteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Minutes", "MinuteTypeId", "dbo.MinuteTypes");
            DropIndex("dbo.Minutes", new[] { "MinuteTypeId" });
            AddColumn("dbo.Minutes", "MinuteType", c => c.Int(nullable: false));
            DropColumn("dbo.Minutes", "MinuteTypeId");
            DropTable("dbo.MinuteTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MinuteTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Minutes", "MinuteTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Minutes", "MinuteType");
            CreateIndex("dbo.Minutes", "MinuteTypeId");
            AddForeignKey("dbo.Minutes", "MinuteTypeId", "dbo.MinuteTypes", "Id", cascadeDelete: true);
        }
    }
}
