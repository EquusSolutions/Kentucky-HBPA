namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinuteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Minutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        MinuteTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MinuteTypes", t => t.MinuteTypeId, cascadeDelete: true)
                .Index(t => t.MinuteTypeId);
            
            CreateTable(
                "dbo.MinuteTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Minutes", "MinuteTypeId", "dbo.MinuteTypes");
            DropIndex("dbo.Minutes", new[] { "MinuteTypeId" });
            DropTable("dbo.MinuteTypes");
            DropTable("dbo.Minutes");
        }
    }
}
