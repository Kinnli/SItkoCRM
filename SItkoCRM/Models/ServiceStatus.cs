using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("ServiceStatuses")]
    public class ServiceStatus : BaseModel<int>
    {
        public string Name { get; set; }

        public List<Service> Services { get; set; }
    }
}
