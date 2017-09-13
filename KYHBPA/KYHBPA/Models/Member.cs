using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Member
    {
        public int Id { get; set; }

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
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

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
    }
}