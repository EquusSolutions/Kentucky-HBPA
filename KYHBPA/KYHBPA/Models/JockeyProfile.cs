using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class JockeyProfile
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public Document Image { get; set; }
    }
}