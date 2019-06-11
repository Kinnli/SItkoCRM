using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("Servers")]
    public class Server : BaseModel<int>
    {
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public string IPv6 { get; set; }

        public List<Host> Hosts { get; set; }
    }
}
