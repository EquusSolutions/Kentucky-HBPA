using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class PollViewModel
    {
        public Poll Poll { get; set; }
        public List<PollOption> PollOptions { get; set; }
    }
}