using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Email { get; set; }
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public DateTime Posted { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}