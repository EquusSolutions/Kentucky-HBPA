using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KYHBPA.Models
{
    public class CallToAction
    {
        public int ID { get; set; }
        public string URL { get; set; }
        public string Headline { get; set; }
        public string Summary { get; set; }
        [EnumDataType(typeof(ActionType))]
        [DisplayName("Call to Action Type")]
        public ActionType TypeOfAction { get; set; }
        public Document Image { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }

    public enum ActionType
    {
        Legislation,
        Petition,
        Cause,
        Fundraiser,
        Other
    }
}