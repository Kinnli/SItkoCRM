using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("Bills")]
    public class Bill : BaseModel<int>
    {
        public int Sum { get; set; }

        public bool IsBilled { get; set; }
        public bool IsSent { get; set; }
        public bool IsPayed { get; set; }

        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))] public Service Service { get; set; }
    }

    public class BillsRepository : Repository<Bill, int, CRMContainer>
    {
        public BillsRepository(RepositoryContext<Bill, int, CRMContainer> repositoryContext) : base(repositoryContext)
        {
        }
    }
}
