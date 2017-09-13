using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class MinuteType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}