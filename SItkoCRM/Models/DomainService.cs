using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("DomainServices")]
    public class DomainService : BaseModel<int>
    {
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))] public Service Service { get; set; }

        public int DomainId { get; set; }

        [ForeignKey(nameof(DomainId))] public Domain Domain { get; set; }
    }
}
