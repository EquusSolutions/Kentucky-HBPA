//Steps for making a model, then a controller which will then make a view.
//Step 1: Go to Models class and then create a new class in there
//Step 2: Create the fields for the table in the database
//Step 3: Go to team explorer fetch and then pull 
//Step 4: updata-database in the Paclage Manager Console
//Step 5: add-migration AddNewsTable to Paclage Manager Console
//Step 6: Then add it to the IdentityModels
//Step 7: Update-database to Paclage Manager Console
//Step 8: Go to Controller class and right-click and click add and then click on controller
//Step 9: Then click add once you fill out the required fields and then click add

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Models
{
    //add something to say the difference between local and national
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