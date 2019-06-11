using Microsoft.EntityFrameworkCore;

namespace SitkoCRM.Models
{
    public class CRMContainer : DbContext
    {
        public CRMContainer(DbContextOptions<CRMContainer> options)
            :base(options)
        {
        }

       

        public DbSet<Bills> Bills { get; set; }
        public DbSet<ClientContacts> ClientContacts { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Domains> Domains { get; set; }
        public DbSet<DomainsServices> DomainsServices { get; set; }
        public DbSet<DomainsStatuses> DomainsStatuses { get; set; }
        public DbSet<Hosts> Hosts { get; set; }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Servers> Servers { get; set; }
        public DbSet<ServicesPrices> Prices { get; set; }
        public DbSet<ServicesStatuses> ServicesStatuses { get; set; }

    }
}
