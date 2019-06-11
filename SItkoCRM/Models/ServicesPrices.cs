using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitkoCRM.Models
{
    public class ServicesPrices:BaseModel
    {
        [Key]
        public int SerPriceId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public List<Services> Services { get; set; }
    }
}
