using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class DomainsServices : BaseModel
    {
        [Key] public int Id { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")] public Services Service { get; set; }

        public int DomainId { get; set; }

        [ForeignKey("DomainId")] public Domains Domain { get; set; }
    }
}