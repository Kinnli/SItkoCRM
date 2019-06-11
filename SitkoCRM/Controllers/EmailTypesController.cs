using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class EmailTypesController : RestController<EmailType, Models.EmailType,int>
    {
        public EmailTypesController(ApiControllerContext<Models.EmailType,int>context):base(context)
        {
                
        }

    }
    public class EmailType : RestModel<Models.EmailType, int>
    {
        public string Name { get; set; }
        public override void ParseEntity(Models.EmailType entity)
        {
            Name = entity.Name;
        }

        public override void FillEntity(Models.EmailType entity)
        {
            entity.Name = Name;
        }
    }
}