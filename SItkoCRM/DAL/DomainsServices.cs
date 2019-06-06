using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class DomainsServices:BaseModel
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Services Service { get; set; }

        public int DomainId { get; set; }
        [ForeignKey("DomainId")]
        public Domains Domain { get; set; }

    }
}
