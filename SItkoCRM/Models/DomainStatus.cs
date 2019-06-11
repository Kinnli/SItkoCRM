using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("DomainStatuses")]
    public class DomainStatus : BaseModel<int>
    {
        public string Name { get; set; }

        public List<Domain> Domains { get; set; }
    }
}
