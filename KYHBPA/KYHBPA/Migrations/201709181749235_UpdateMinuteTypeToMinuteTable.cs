namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMinuteTypeToMinuteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Minute", "MinuteTypeId", "dbo.MinuteType");
            DropIndex("dbo.Minute", new[] { "MinuteTypeId" });
            AddColumn("dbo.Minute", "MinuteType", c => c.Int(nullable: false));
            DropColumn("dbo.Minute", "MinuteTypeId");
            DropTable("dbo.MinuteType");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MinuteType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Minute", "MinuteTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Minute", "MinuteType");
            CreateIndex("dbo.Minute", "MinuteTypeId");
            AddForeignKey("dbo.Minute", "MinuteTypeId", "dbo.MinuteType", "Id", cascadeDelete: true);
        }
    }
}
