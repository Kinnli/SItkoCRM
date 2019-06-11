using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class DomainsController : RestController<Domain, Models.Domain,int>
    {
        public DomainsController(ApiControllerContext<Models.Domain,int> context):base(context)
        {
            
        }
    }

    public class Domain : RestModel<Models.Domain, int>
    {
        public string Name { get; set; }

        public override void ParseEntity(Models.Domain entity)
        {
            Name = entity.Name;
        }

        public override void FillEntity(Models.Domain entity)
        {
            entity.Name = Name;
        }
    }


}
