namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePropertyAppUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "MemberId");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "MemberDate");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "RacingLicense");
            DropColumn("dbo.AspNetUsers", "Income");
            DropColumn("dbo.AspNetUsers", "IsTrainer");
            DropColumn("dbo.AspNetUsers", "IsHorseOwner");
            DropColumn("dbo.AspNetUsers", "IsStaff");
            DropColumn("dbo.AspNetUsers", "IsAgreedToTerms");
            DropColumn("dbo.AspNetUsers", "Signature");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Signature", c => c.String());
            AddColumn("dbo.AspNetUsers", "IsAgreedToTerms", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsStaff", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsHorseOwner", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsTrainer", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Income", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.AspNetUsers", "RacingLicense", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zip", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "MemberDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "MemberId", c => c.Int(nullable: false));
        }
    }
}
