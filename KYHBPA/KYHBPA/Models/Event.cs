using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }
        public DateTime Time { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}