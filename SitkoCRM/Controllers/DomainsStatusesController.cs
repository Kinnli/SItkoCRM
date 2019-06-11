using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;
using SitkoCRM.Models;

namespace SitkoCRM.Controllers
{
    public class DomainsStatusesController : RestController<DomainStatus, Models.DomainStatus,int>
    {
        public DomainsStatusesController(ApiControllerContext<Models.DomainStatus,int> context) :base(context)
        {
                
        }
    }

    public class DomainStatus : RestModel<Models.DomainStatus, int>
    {
        public string Name { get; set; }


        public override void ParseEntity(Models.DomainStatus entity)
        {
            Name = entity.Name;
        }

        public override void FillEntity(Models.DomainStatus entity)
        {
            entity.Name = Name;
        }
    }
}
