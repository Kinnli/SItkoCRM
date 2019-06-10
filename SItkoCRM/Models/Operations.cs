using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SitkoCRM.DAL
{
    public class Operations:BaseModel
    {
        [Key]
        public int OperationId { get; set; }
        [Column(TypeName = "jsonb")]
        public string Data { get; set; }
    }
}
