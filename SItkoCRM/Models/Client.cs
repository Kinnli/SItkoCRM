using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("Clients")]
    public class Client : BaseModel<int>
    {
        public string Name { get; set; }
        public string KPP { get; set; }
        public string INN { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public List<ClientContact> ClientContacts { get; set; }
        public List<Service> Services { get; set; }
    }
}
