using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitkoCRM.Models
{
    public class Servers:BaseModel
    {
        [Key]
        public int ServerId { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public string IPv6 { get; set; }

        public List<Hosts> Hosts { get; set; }

    }
}
