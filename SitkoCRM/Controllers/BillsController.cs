using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class BillsController : RestController<Bill, Models.Bill, int>
    {
        public BillsController(ApiControllerContext<Models.Bill, int> context) : base(context)
        {
        }
    }

    public class Bill : RestModel<Models.Bill, int>
    {
        public int Sum { get; set; }

        public bool IsBilled { get; set; }
        public bool IsSent { get; set; }
        public bool IsPayed { get; set; }

        public override void ParseEntity(Models.Bill entity)
        {
            Sum = entity.Sum;
            IsBilled = entity.IsBilled;
            IsSent = entity.IsSent;
            IsPayed = entity.IsPayed;
        }

        public override void FillEntity(Models.Bill entity)
        {
            entity.Sum = Sum;
        }
    }
}
