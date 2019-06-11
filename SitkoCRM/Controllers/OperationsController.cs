using Microsoft.AspNetCore.Mvc;
using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class OperationsController : RestController<Operation,Models.Operation,int>
    {
        public OperationsController(ApiControllerContext<Models.Operation,int> context):base(context)
        {
                
        }
    }

    public class Operation : RestModel<Models.Operation, int>
    {
        public string Data { get; set; }

        public override void ParseEntity(Models.Operation entity)
        {
            Data = entity.Data;
        }

        public override void FillEntity(Models.Operation entity)
        {
            entity.Data = Data;
        }
    }
}
