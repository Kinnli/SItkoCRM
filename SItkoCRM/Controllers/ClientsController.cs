using SitkoCRM.Components.API;

namespace SitkoCRM.Controllers
{
    public class ClientsController : RestController<Client, Models.Client, int>
    {
        public ClientsController(ApiControllerContext<Models.Client, int> context) : base(context)
        {
        }
    }

    public class Client : RestModel<Models.Client, int>
    {
        public string Name { get; set; }
        public string KPP { get; set; }
        public string INN { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }

        public override void ParseEntity(Models.Client entity)
        {
            Name = entity.Name;
            KPP = entity.KPP;
            INN = entity.INN;
            Note = entity.Note;
            Active = entity.Active;
        }

        public override void FillEntity(Models.Client entity)
        {
            entity.Name = Name;
            entity.KPP = entity.KPP;
            entity.INN = INN;
            entity.Note = entity.Note;
        }
    }
}
