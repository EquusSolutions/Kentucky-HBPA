using KYHBPA.Models;

namespace KYHBPA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KYHBPA.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KYHBPA.Models.ApplicationDbContext context)
        {
            context.Minutes.AddOrUpdate(
                m => m.Id,
                new Minutes { Id = 1, Date = DateTime.Now,
                    MinutesType = MinutesType.Board, Note = "Test Board Minutes"},
                new Minutes { Id = 2, Date = DateTime.Now,
                    MinutesType = MinutesType.Community, Note = "Test Community Minutes" },
                new Minutes { Id = 3, Date = DateTime.Now,
                    MinutesType = MinutesType.Other, Note = "Test Other Minutes" }
            );

            context.Members.AddOrUpdate(
                m => m.Email,
                new Member { Address = "123 Test Road", City = "Louisville", State = "KY"
                    , Zip = "40202", Email = "test@test.com", DateOfBirth = DateTime.Now.AddYears(-20),
                    FirstName = "Corey", LastName = "Cooley", Income = 100000, Id = 1, IsAgreedToTerms = true,
                    IsHorseOwner = false, IsStaff = true, IsTrainer = false, MemberDate = DateTime.Now,
                    Signature = "Corey Cooley"}
                );
        }
    }
}
