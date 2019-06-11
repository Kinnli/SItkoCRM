using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("Hosts")]
    public class Host : BaseModel<int>
    {
        public string Name { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))] public Service Service { get; set; }

        public int ServerId { get; set; }

        [ForeignKey(nameof(ServerId))] public Server Server { get; set; }

        public List<Domain> Domains { get; set; }
    }
}
