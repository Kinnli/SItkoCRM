using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class HostsController : RestController<Host,Models.Host,int>
    {
        public HostsController(ApiControllerContext<Models.Host,int> context):base(context)
        {
                
        }        
    }

    public class Host : RestModel<Models.Host, int>
    {
        public string Name { get; set; }
        public override void ParseEntity(Models.Host entity)
        {
            Name = entity.Name;
        }

        public override void FillEntity(Models.Host entity)
        {
            entity.Name = Name;
        }
    }
}
