using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Minute
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        public MinuteType MinuteType { get; set; }

        [DisplayName("Minute Type")]
        public byte MinuteTypeId { get; set; }
    }
}