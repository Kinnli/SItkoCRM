using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class ClientContacts:BaseModel
    {
        [Key]
        public int ContactId { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Clients Client { get; set; }
    }
}
