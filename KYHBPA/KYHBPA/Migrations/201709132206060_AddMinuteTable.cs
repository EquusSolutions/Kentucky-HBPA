namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinuteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Minute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        MinuteTypeId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MinuteType", t => t.MinuteTypeId, cascadeDelete: true)
                .Index(t => t.MinuteTypeId);
            
            CreateTable(
                "dbo.MinuteType",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Minute", "MinuteTypeId", "dbo.MinuteType");
            DropIndex("dbo.Minute", new[] { "MinuteTypeId" });
            DropTable("dbo.MinuteType");
            DropTable("dbo.Minute");
        }
    }
}
