using System;
using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class ServicesController : RestController<Service,Models.Service,int>
    {
        public ServicesController(ApiControllerContext<Models.Service,int>context):base(context)
        {
                
        }
    }

    public class Service : RestModel<Models.Service, int>
    {
        public DateTime ActiveTo { get; set; }

        public override void ParseEntity(Models.Service entity)
        {
            ActiveTo = entity.ActiveTo;
        }

        public override void FillEntity(Models.Service entity)
        {
            entity.ActiveTo = ActiveTo;
        }
    }
}
