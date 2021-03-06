﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KYHBPA.Models.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Member Id")]
        public int MemberId { get; set; }
        [DisplayName("File Bytes")]
        public byte[] FileBytes { get; set; }
        public int ContentLength { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }
        [DisplayName("Document Discriminator")]
        [EnumDataType(typeof(DocumentDiscriminator))]
        public DocumentDiscriminator Discriminator { get; set; }
        public DateTime UploadDate { get; set; }
    }
}