using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("Operations")]
    public class Operation : BaseModel<int>
    {
        [Column(TypeName = "jsonb")] public string Data { get; set; }
    }

    public class OperationsRepository : Repository<Operation, int, CRMContainer>
    {
        public OperationsRepository(RepositoryContext<Operation, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
