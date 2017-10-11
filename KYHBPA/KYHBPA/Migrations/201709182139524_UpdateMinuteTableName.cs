namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMinuteTableName : DbMigration
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
                        MinutesType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Minute");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Minute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(),
                        Date = c.DateTime(nullable: false),
                        MinuteType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Minutes");
        }
    }
}
