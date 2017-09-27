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
                new Minutes
                {
                    Id = 1,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Board,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent at ornare nunc. Fusce at odio nulla. Fusce ornare, risus vel viverra pretium, justo leo facilisis nunc, quis tincidunt leo diam id augue. Vivamus libero ante, tincidunt vitae diam in, rhoncus rhoncus nibh. Phasellus et ligula elementum neque aliquam elementum luctus id nulla. Sed vel ultrices nunc. Cras luctus ultricies sapien, sed rutrum eros efficitur in. Nulla sed laoreet libero, vel ultrices massa. Aenean lobortis quam imperdiet est aliquam tincidunt."
                },
                new Minutes
                {
                    Id = 2,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Board,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consectetur sagittis blandit. Phasellus sed sem ac massa elementum fermentum sed a dolor. Donec auctor dictum nulla. Sed vitae ante tempor, pellentesque nibh et, venenatis justo. Vivamus pellentesque diam elit, vel congue velit sodales a. Nunc hendrerit dui tempus, lobortis elit vitae, sodales lorem. Morbi mauris lectus, interdum vitae turpis ac, venenatis dignissim velit. In id sapien maximus, dapibus risus in, aliquet ex. Donec aliquam consequat blandit. Nunc nec pharetra tortor. Sed vitae laoreet sapien. Nam laoreet felis erat. Phasellus vestibulum tincidunt est eget egestas. Nulla eros ante, malesuada sit amet ex sagittis, ultrices faucibus nisi. Nunc porta ut urna a bibendum. Integer elementum urna vel sem dignissim, a ultrices dui ullamcorper."
                },
                new Minutes
                {
                    Id = 3,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Community,
                    Note = "Test Community Minutes"
                },
                new Minutes
                {
                    Id = 4,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Other,
                    Note = "Test Other Minutes"
                }
            );

            context.Members.AddOrUpdate(
                m => m.Email,
                new Member
                {
                    Address = "123 Test Road",
                    City = "Louisville",
                    State = "KY"
                    ,
                    Zip = "40202",
                    Email = "test@test.com",
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    FirstName = "Corey",
                    LastName = "Cooley",
                    Income = 100000,
                    Id = 1,
                    IsAgreedToTerms = true,
                    IsHorseOwner = false,
                    IsStaff = true,
                    IsTrainer = false,
                    MemberDate = DateTime.Now,
                    Signature = "Corey Cooley"
                },
                new Member
                {
                    Address = "456 Test Blvd",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40215",
                    Email = "test@email.com",
                    DateOfBirth = DateTime.Now.AddYears(-39),
                    FirstName = "John",
                    LastName = "Hopson",
                    Income = 1000000,
                    Id = 2,
                    IsAgreedToTerms = true,
                    IsHorseOwner = false,
                    IsStaff = true,
                    IsTrainer = false,
                    MemberDate = DateTime.Now,
                    Signature = "John C Hopson"
                },
                new Member
                {
                    Address = "998 Test Run",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40201",
                    Email = "test@email.com",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    FirstName = "Mikey",
                    LastName = "Benedetto",
                    Income = 100,
                    Id = 3,
                    IsAgreedToTerms = true,
                    IsHorseOwner = false,
                    IsStaff = true,
                    IsTrainer = false,
                    MemberDate = DateTime.Now,
                    Signature = "Mikey Benedetto"
                },
                new Member
                {
                    Address = "111 Test Ave",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40204",
                    Email = "test@email.com",
                    DateOfBirth = DateTime.Now.AddYears(-23),
                    FirstName = "Andrew",
                    LastName = "Walz",
                    Income = 100000,
                    Id = 4,
                    IsAgreedToTerms = true,
                    IsHorseOwner = false,
                    IsStaff = true,
                    IsTrainer = false,
                    MemberDate = DateTime.Now,
                    Signature = "Andrew Walz"
                },
                new Member
                {
                    Address = "528 Test Run",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40200",
                    Email = "test@email.com",
                    DateOfBirth = DateTime.Now.AddYears(-22),
                    FirstName = "Daniella",
                    LastName = "Tejeira",
                    Income = 1000001,
                    Id = 5,
                    IsAgreedToTerms = true,
                    IsHorseOwner = false,
                    IsStaff = true,
                    IsTrainer = false,
                    MemberDate = DateTime.Now,
                    Signature = "Daniella Tejeira"
                }
                );
        }
    }
}