namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToPollTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Polls", "Name");
        }
    }
}
