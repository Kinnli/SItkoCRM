using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("ServicePrices")]
    public class ServicePrice : BaseModel<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public List<Service> Services { get; set; }
    }

    public class ServicePricesRepository : Repository<ServicePrice, int, CRMContainer>
    {
        public ServicePricesRepository(RepositoryContext<ServicePrice, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
