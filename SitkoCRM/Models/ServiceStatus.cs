using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("ServiceStatuses")]
    public class ServiceStatus : BaseModel<int>
    {
        public string Name { get; set; }

        public List<Service> Services { get; set; }
    }

    public class ServiceStatusesRepository : Repository<ServiceStatus, int, CRMContainer>
    {
        public ServiceStatusesRepository(RepositoryContext<ServiceStatus, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
