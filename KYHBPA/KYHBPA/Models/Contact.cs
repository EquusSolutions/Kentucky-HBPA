using System;
using System.Collections.Generic;
//Must have this using statement if you want to use [DisplayName]
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(300, MinimumLength = 5)]
        [Required]
        public string Note { get; set; }
    }
}