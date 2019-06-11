using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("ServicePrices")]
    public class ServicePrice : BaseModel<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public List<Service> Services { get; set; }
    }
}
