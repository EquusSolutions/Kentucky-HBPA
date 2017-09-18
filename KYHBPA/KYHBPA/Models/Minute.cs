using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Minute
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Minute Type")]
        [EnumDataType(typeof(MinuteType))]
        public MinuteType MinuteType { get; set; }
    }

    public enum MinuteType
    {
        Board,
        Community,
        Other
    }
}