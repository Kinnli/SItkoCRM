using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class EmailMessage : BaseModel<int>
    {
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))] public EmailType Type { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public string Attachment { get; set; }

        public string AttachmentFilename{get;set;}

        public DateTime SendedAt { get; set; }
        public bool IsSended { get; set; }



    }
}
