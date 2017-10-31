using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Poll> Polls { get; set; }
        public List<News> News { get; set; }
        public Contact Contact { get; set; }

        public HomeViewModel()
        {
            Polls = new List<Poll>();
            News = new List<News>();
            Contact = new Contact();
        }
    }
}