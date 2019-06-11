using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    [Table("Bills")]
    public class Bill : BaseModel<int>
    {
        public int Sum { get; set; }

        public bool IsBilled { get; set; }
        public bool IsSended { get; set; }
        public bool IsPayed { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))] public Service Service { get; set; }
    }
}
