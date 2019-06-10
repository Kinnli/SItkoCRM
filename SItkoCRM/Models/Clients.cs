using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class Clients:BaseModel
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string KPP { get; set; }
        public string INN { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public List<ClientContacts> ClientContacts { get; set; }
        public List<Services> Services { get; set; }
    }
}
