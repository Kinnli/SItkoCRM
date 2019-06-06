using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class Hosts:BaseModel
    {
        [Key]
        public int HostId { get; set; }

        public string Name { get; set; }

        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Services Service { get; set; }

        public int ServerId { get; set; }
        [ForeignKey("ServerId")]
        public Servers Server { get; set; }
        public List<Domains> Domains { get; set; }

    }
}
