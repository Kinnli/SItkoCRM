using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class DomainsStatuses : BaseModel
    {
        [Key]
        public int StatusId { get; set; }

        public string Name { get; set; }
      
        public List<Domains> Domains { get; set; }
    }
}
