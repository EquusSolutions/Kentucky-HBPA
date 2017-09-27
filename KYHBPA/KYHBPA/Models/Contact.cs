using System;
using System.Collections.Generic;
//Must have this using statement if you want to use [DisplayName]
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
    }
}