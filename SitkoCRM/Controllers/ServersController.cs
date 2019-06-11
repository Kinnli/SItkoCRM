using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class ServersController : RestController<Server,Models.Server,int>
    {
        public ServersController(ApiControllerContext<Models.Server,int> context):base(context)
        {
            
        }
    }

    public class Server : RestModel<Models.Server, int>
    {
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public string IPv6 { get; set; }

        public override void ParseEntity(Models.Server entity)
        {
            Name = entity.Name;
            IPv4 = entity.IPv4;
            IPv6 = entity.IPv6;
        }

        public override void FillEntity(Models.Server entity)
        {
            entity.Name = Name;
            entity.IPv4 = IPv4;
            entity.IPv6 = IPv6;
        }
    }
}
