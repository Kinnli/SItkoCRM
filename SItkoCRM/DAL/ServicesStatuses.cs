using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class ServicesStatuses:BaseModel
    {
        [Key]
        public int SerStatusId { get; set; }
        public string Name { get; set; }

        public List<Services> Services { get; set; }

    }
}
