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
        [DisplayName("First Name")]
        [StringLength(50, MinimumLength=1, ErrorMessage = "Minimum string length is 1.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Minimum string length is 1.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Minimum string length is 5.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Minimum string length is 5.")]
        public string Note { get; set; }

    }
}