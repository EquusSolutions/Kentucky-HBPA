using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class PollOption
    {
        public int Id { get; set; }
        public int Votes { get; set; }
        public string Title { get; set; }
        public Poll Poll { get; set; }
        public int PollId { get; set; }
    }
}