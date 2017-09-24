using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<PollOption> PollOptions { get; set; }
    }
}