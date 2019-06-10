using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
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
