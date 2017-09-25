using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Poll
    {
        // https://stackoverflow.com/questions/38513599/asp-net-mvc-how-to-dynamically-add-items-to-an-object-and-bind-it-to-the-contr
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public List<PollOption> PollOptions { get; set; }
    }
}