using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Summary { get; set; }
        public string URL { get; set; }
        public Document Picture { get; set; }
        public int PictureId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}