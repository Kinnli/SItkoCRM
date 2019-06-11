using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class ServicesPricesController : RestController<ServicePrice,Models.ServicePrice,int>
    {
        public ServicesPricesController(ApiControllerContext<Models.ServicePrice,int> context) :base(context)
        {
                
        }        
    }

    public class ServicePrice : RestModel<Models.ServicePrice, int>
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override void ParseEntity(Models.ServicePrice entity)
        {
            Name = entity.Name;
            Value = entity.Value;
        }

        public override void FillEntity(Models.ServicePrice entity)
        {
            entity.Name = Name;
            entity.Value = Value;
        }
    }
}
