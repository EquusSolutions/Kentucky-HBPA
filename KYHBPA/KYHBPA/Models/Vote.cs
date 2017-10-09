using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public Guid Voter { get; set; }
        public int PollId { get; set; }
    }
}