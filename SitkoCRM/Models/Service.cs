using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("Services")]
    public class Service : BaseModel<int>
    {
        public DateTime ActiveTo { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))] public Client Client { get; set; }

        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))] public ServiceStatus Status { get; set; }

        public int PriceId { get; set; }

        [ForeignKey(nameof(StatusId))] public ServicePrice Price { get; set; }

        public List<Host> Hosts { get; set; }
        public List<DomainService> DomainsServices { get; set; }
        public List<Bill> Bills { get; set; }
    }

    public class ServicesRepository : Repository<Service, int, CRMContainer>
    {
        public ServicesRepository(RepositoryContext<Service, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
