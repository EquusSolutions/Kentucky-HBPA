﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Published { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Posted { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Modified { get; set; }
        [DisplayName("Post Type")]
        [EnumDataType(typeof(PostType))]
        public PostType PostType { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}