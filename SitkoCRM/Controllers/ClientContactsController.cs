using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class ClientContactsController : RestController<ClientContact, Models.ClientContact,int >
    {
        public ClientContactsController(ApiControllerContext<Models.ClientContact,int> context):base(context)
        {
                
        }
    }

    public class ClientContact : RestModel<Models.ClientContact, int>
    {
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public override void FillEntity(Models.ClientContact entity)
        {
            entity.PhoneNum = PhoneNum;
            entity.Email = Email;
            entity.Name = Name;
        }

        public override void ParseEntity(Models.ClientContact entity)
        {
            PhoneNum = entity.PhoneNum;
            Email = entity.Email;
            Name = entity.Name;
        }
    }
}
