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
                    MinutesType = MinutesType.Board,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consectetur sagittis blandit. Phasellus sed sem ac massa elementum fermentum sed a dolor. Donec auctor dictum nulla. Sed vitae ante tempor, pellentesque nibh et, venenatis justo. Vivamus pellentesque diam elit, vel congue velit sodales a. Nunc hendrerit dui tempus, lobortis elit vitae, sodales lorem. Morbi mauris lectus, interdum vitae turpis ac, venenatis dignissim velit. In id sapien maximus, dapibus risus in, aliquet ex. Donec aliquam consequat blandit. Nunc nec pharetra tortor. Sed vitae laoreet sapien. Nam laoreet felis erat. Phasellus vestibulum tincidunt est eget egestas. Nulla eros ante, malesuada sit amet ex sagittis, ultrices faucibus nisi. Nunc porta ut urna a bibendum. Integer elementum urna vel sem dignissim, a ultrices dui ullamcorper."
                },
                new Minutes
                {
                    Id = 4,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Board,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consectetur sagittis blandit. Phasellus sed sem ac massa elementum fermentum sed a dolor. Donec auctor dictum nulla. Sed vitae ante tempor, pellentesque nibh et, venenatis justo. Vivamus pellentesque diam elit, vel congue velit sodales a. Nunc hendrerit dui tempus, lobortis elit vitae, sodales lorem. Morbi mauris lectus, interdum vitae turpis ac, venenatis dignissim velit. In id sapien maximus, dapibus risus in, aliquet ex. Donec aliquam consequat blandit. Nunc nec pharetra tortor. Sed vitae laoreet sapien. Nam laoreet felis erat. Phasellus vestibulum tincidunt est eget egestas. Nulla eros ante, malesuada sit amet ex sagittis, ultrices faucibus nisi. Nunc porta ut urna a bibendum. Integer elementum urna vel sem dignissim, a ultrices dui ullamcorper."
                },
                new Minutes
                {
                    Id = 5,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Community,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consectetur sagittis blandit. Phasellus sed sem ac massa elementum fermentum sed a dolor. Donec auctor dictum nulla. Sed vitae ante tempor, pellentesque nibh et, venenatis justo. Vivamus pellentesque diam elit, vel congue velit sodales a. Nunc hendrerit dui tempus, lobortis elit vitae, sodales lorem. Morbi mauris lectus, interdum vitae turpis ac, venenatis dignissim velit. In id sapien maximus, dapibus risus in, aliquet ex. Donec aliquam consequat blandit. Nunc nec pharetra tortor. Sed vitae laoreet sapien. Nam laoreet felis erat. Phasellus vestibulum tincidunt est eget egestas. Nulla eros ante, malesuada sit amet ex sagittis, ultrices faucibus nisi. Nunc porta ut urna a bibendum. Integer elementum urna vel sem dignissim, a ultrices dui ullamcorper."
                },
                new Minutes
                {
                    Id = 6,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Community,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consectetur sagittis blandit. Phasellus sed sem ac massa elementum fermentum sed a dolor. Donec auctor dictum nulla. Sed vitae ante tempor, pellentesque nibh et, venenatis justo. Vivamus pellentesque diam elit, vel congue velit sodales a. Nunc hendrerit dui tempus, lobortis elit vitae, sodales lorem. Morbi mauris lectus, interdum vitae turpis ac, venenatis dignissim velit. In id sapien maximus, dapibus risus in, aliquet ex. Donec aliquam consequat blandit. Nunc nec pharetra tortor. Sed vitae laoreet sapien. Nam laoreet felis erat. Phasellus vestibulum tincidunt est eget egestas. Nulla eros ante, malesuada sit amet ex sagittis, ultrices faucibus nisi. Nunc porta ut urna a bibendum. Integer elementum urna vel sem dignissim, a ultrices dui ullamcorper."
                },
                new Minutes
                {
                    Id = 7,
                    Date = DateTime.Now,
                    MinutesType = MinutesType.Community,
                    Note = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque consectetur sagittis blandit. Phasellus sed sem ac massa elementum fermentum sed a dolor. Donec auctor dictum nulla. Sed vitae ante tempor, pellentesque nibh et, venenatis justo. Vivamus pellentesque diam elit, vel congue velit sodales a. Nunc hendrerit dui tempus, lobortis elit vitae, sodales lorem. Morbi mauris lectus, interdum vitae turpis ac, venenatis dignissim velit. In id sapien maximus, dapibus risus in, aliquet ex. Donec aliquam consequat blandit. Nunc nec pharetra tortor. Sed vitae laoreet sapien. Nam laoreet felis erat. Phasellus vestibulum tincidunt est eget egestas. Nulla eros ante, malesuada sit amet ex sagittis, ultrices faucibus nisi. Nunc porta ut urna a bibendum. Integer elementum urna vel sem dignissim, a ultrices dui ullamcorper."
                }
            );

            context.Members.AddOrUpdate(
                m => m.Email,
                new Member
                {
                    Id = 1,
                    Email = "Admin@Kyhbpa.com",
                    FirstName = "Admin",
                    LastName = "Kyhbpa",
                    PhoneNumber = "(555)-555-5555",
                    Address = "123 Test Road",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40202",
                    RacingLicense = "KY123456789",                    
                    IsTrainer = true,
                    IsHorseOwner = true,
                    IsStaff = true,
                    IsAgreedToTerms = true,
                    Signature = "Admin Kyhbpa",
                    MemberDate = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddYears(-18)
                },
                new Member
                {
                    Id = 2,
                    Email = "Staff@Kyhbpa.com",
                    FirstName = "Staff",
                    LastName = "Kyhbpa",
                    PhoneNumber = "(555)-555-5555",
                    Address = "123 Test Street",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40202",
                    RacingLicense = "KY987654321",
                    IsTrainer = true,
                    IsHorseOwner = true,
                    IsStaff = true,
                    IsAgreedToTerms = true,
                    Signature = "Staff Kyhbpa",
                    MemberDate = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddYears(-18)
                },
                new Member
                {
                    Id = 3,
                    Email = "Guest@Kyhbpa.com",
                    FirstName = "Guest",
                    LastName = "Kyhbpa",
                    PhoneNumber = "(555)-555-5555",
                    Address = "321 Test Road",
                    City = "Louisville",
                    State = "KY",
                    Zip = "40202",
                    RacingLicense = "",
                    IsTrainer = false,
                    IsHorseOwner = false,
                    IsAgreedToTerms = true,
                    Signature = "Guest Kyhbpa",
                    MemberDate = DateTime.Now,
                    DateOfBirth = DateTime.Now.AddYears(-18)
                }
                );
        }
    }
}