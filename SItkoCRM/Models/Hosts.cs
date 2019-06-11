using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class Hosts : BaseModel
    {
        [Key] public int HostId { get; set; }

        public string Name { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")] public Services Service { get; set; }

        public int ServerId { get; set; }

        [ForeignKey("ServerId")] public Servers Server { get; set; }

        public List<Domains> Domains { get; set; }
    }
}