namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'287e44f7-966b-4a60-b1a1-822107794228', N'Admin@Kyhbpa.com', 0, N'AJQIEUY68V3SwdG2tffsNMR0iWMX56AcAMZzf/I9ltCBmz0u/VSwN5YnujRkxtwgdA==', N'82f8bc30-6f0f-4efa-b53b-18735f477249', NULL, 0, 0, NULL, 1, 0, N'Admin@Kyhbpa.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6f15ba35-4c4c-479e-ab3a-195577760f90', N'Guest@kyhbpa.com', 0, N'AFwdN9Mk2zMn4Pqbp4QqsuVQBg4NSUqVvXD38TyIVjwMe5XVFMQk6FlYg0b+sGRBvg==', N'10444293-3dcb-49b2-86d6-2e8faf4cac45', NULL, 0, 0, NULL, 1, 0, N'Guest@kyhbpa.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'19bc993b-47a7-4b9c-8db1-7bd8887c2831', N'Administrator')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'287e44f7-966b-4a60-b1a1-822107794228', N'19bc993b-47a7-4b9c-8db1-7bd8887c2831')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
