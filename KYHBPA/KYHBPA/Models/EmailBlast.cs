using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KYHBPA.Models
{
    public class EmailBlast
    {
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public Document Attachment { get; set; }  //look at document view upload attachments code
        public string Body { get; set; }

    }
}