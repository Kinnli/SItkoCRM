using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class Bills : BaseModel
    {
        [Key] public int BillId { get; set; }

        public int Sum { get; set; }

        public bool IsBilled { get; set; }
        public bool IsSended { get; set; }
        public bool IsPayed { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey("ServiceId")] public Services Service { get; set; }
    }
}
