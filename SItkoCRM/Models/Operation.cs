using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("Operations")]
    public class Operation : BaseModel<int>
    {
        [Column(TypeName = "jsonb")] public string Data { get; set; }
    }
}
