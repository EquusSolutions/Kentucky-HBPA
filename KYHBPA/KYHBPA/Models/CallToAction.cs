using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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