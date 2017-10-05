using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class MemberViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        // General Information
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Member Date")]
        public DateTime MemberDate { get; set; }

        // Contact Information
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        //public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Additional Information
        [Display(Name = "Racing License")]
        public string RacingLicense { get; set; }
        public decimal Income { get; set; }

        // Member Types
        [Display(Name = "Trainer")]
        public bool IsTrainer { get; set; }
        [Display(Name = "Horse Owner")]
        public bool IsHorseOwner { get; set; }
        [Display(Name = "Staff")]
        public bool IsStaff { get; set; }

        // Terms
        [Display(Name = "Agree To Terms")]
        public bool IsAgreedToTerms { get; set; }
        public string Signature { get; set; }
    }
}