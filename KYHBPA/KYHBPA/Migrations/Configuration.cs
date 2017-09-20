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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Minutes.AddOrUpdate(
                m => m.Id,
                new Minutes { Id = 1, Date = DateTime.Now,
                    MinutesType = MinutesType.Board, Note = "Test Board Minutes"},
                new Minutes { Id = 2, Date = DateTime.Now,
                    MinutesType = MinutesType.Community, Note = "Test Community Minutes" },
                new Minutes { Id = 3, Date = DateTime.Now,
                    MinutesType = MinutesType.Other, Note = "Test Other Minutes" }
            );
        }
    }
}
