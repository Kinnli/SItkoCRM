using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class EmailMessagesController : RestController<EmailMessage,Models.EmailMessage,int>
    {
        public EmailMessagesController(ApiControllerContext<Models.EmailMessage,int> context):base(context)
        {
            
        }
    }

    public class EmailMessage : RestModel<Models.EmailMessage, int>
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Attachment { get; set; }
        public string AttachmentFilename { get; set; }

        public override void FillEntity(Models.EmailMessage entity)
        {
            Subject = entity.Subject;
            Message = entity.Message;
            Attachment = entity.Attachment;
            AttachmentFilename = entity.AttachmentFilename;
        }

        public override void ParseEntity(Models.EmailMessage entity)
        {
            entity.Subject = Subject;
            entity.Message = Message;
            entity.Attachment = Attachment;
            entity.AttachmentFilename = AttachmentFilename;
        }
    }
}