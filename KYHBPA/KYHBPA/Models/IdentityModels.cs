using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;
using System;

namespace KYHBPA.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        // General Information
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Member Date")]
        public DateTime MemberDate { get; set; }

        // Contact Information
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        // Additional Information
        [DisplayName("Racing License")]
        public string RacingLicense { get; set; }
        public decimal Income { get; set; }

        // Member Types
        [DisplayName("Trainer")]
        public bool IsTrainer { get; set; }
        [DisplayName("Horse Owner")]
        public bool IsHorseOwner { get; set; }
        [DisplayName("Staff")]
        public bool IsStaff { get; set; }

        // Terms
        [DisplayName("Agree To Terms")]
        public bool IsAgreedToTerms { get; set; }
        public string Signature { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Minutes> Minutes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<PollOption> PollOptions { get; set; }
        public DbSet<News> News { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<KYHBPA.Models.CallToAction> CallToActions { get; set; }
    }
}