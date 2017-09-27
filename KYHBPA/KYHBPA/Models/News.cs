//Steps for making a model, then a controller which will then make a view.
//Step 1: Go to Models class and then create a new class in there
//Step 2: Create the fields for the table in the database
//Step 3: 

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}