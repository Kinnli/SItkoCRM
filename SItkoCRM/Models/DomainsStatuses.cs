using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SitkoCRM.Models
{
    public class DomainsStatuses : BaseModel
    {
        [Key]
        public int StatusId { get; set; }

        public string Name { get; set; }
      
        public List<Domains> Domains { get; set; }
    }
}
