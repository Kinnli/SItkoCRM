using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class ServicesStatusesController : RestController<ServiceStatus,Models.ServiceStatus,int>
    {
        public ServicesStatusesController(ApiControllerContext<Models.ServiceStatus,int> context):base(context)
        { 
        }
    }

    public class ServiceStatus : RestModel<Models.ServiceStatus, int>
    {
        public string Name { get; set; }

        public override void ParseEntity(Models.ServiceStatus entity)
        {
            Name = entity.Name;
        }

        public override void FillEntity(Models.ServiceStatus entity)
        {
            entity.Name = Name;
        }
    }
}
