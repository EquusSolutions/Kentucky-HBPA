using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}