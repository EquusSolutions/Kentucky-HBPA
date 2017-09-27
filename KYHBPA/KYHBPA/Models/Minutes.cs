using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Minutes
    {
        public int Id { get; set; }
        public string Note { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [DisplayName("Minutes Type")]
        [EnumDataType(typeof(MinutesType))]
        public MinutesType MinutesType { get; set; }
    }

    public enum MinutesType
    {
        Board,
        Community,
        Other
    }
}