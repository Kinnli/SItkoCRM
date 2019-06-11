using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitkoCRM.Models
{
    public class ServicesStatuses:BaseModel
    {
        [Key]
        public int SerStatusId { get; set; }
        public string Name { get; set; }

        public List<Services> Services { get; set; }

    }
}
