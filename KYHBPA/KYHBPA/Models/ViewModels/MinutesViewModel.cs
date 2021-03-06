﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class MinutesViewModel
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Minutes Type")]
        [EnumDataType(typeof(MinutesType))]
        public MinutesType MinutesType { get; set; }
    }
}