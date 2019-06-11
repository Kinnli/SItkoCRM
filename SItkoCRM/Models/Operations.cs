using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class Operations:BaseModel
    {
        [Key]
        public int OperationId { get; set; }
        [Column(TypeName = "jsonb")]
        public string Data { get; set; }
    }
}
