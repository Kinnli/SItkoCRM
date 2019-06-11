using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("DomainStatuses")]
    public class DomainStatus : BaseModel<int>
    {
        public string Name { get; set; }

        public List<Domain> Domains { get; set; }
    }

    public class DomainStatusesRepository : Repository<DomainStatus, int, CRMContainer>
    {
        public DomainStatusesRepository(RepositoryContext<DomainStatus, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
