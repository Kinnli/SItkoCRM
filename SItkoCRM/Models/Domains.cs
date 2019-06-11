using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class Domains : BaseModel
    {
        [Key] public int DomainId { get; set; }

        public string Name { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("StatusId")] public DomainsStatuses Status { get; set; }

        public int HostId { get; set; }

        [ForeignKey("HostId")] public Hosts Host { get; set; }

        public List<DomainsServices> DomainsServices { get; set; }
    }
}