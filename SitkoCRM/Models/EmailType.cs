using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.Models
{
    public class EmailType:BaseModel<int>
    {

        public string Name { get; set; }

        public List<EmailMessage> Messages { get; set; }
    }
}
