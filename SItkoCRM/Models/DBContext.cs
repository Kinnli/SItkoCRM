using Microsoft.EntityFrameworkCore;

namespace SitkoCRM.Models
{
    public class CRMContainer : DbContext
    {
        public CRMContainer(DbContextOptions<CRMContainer> options)
            : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<DomainService> DomainsServices { get; set; }
        public DbSet<DomainStatus> DomainsStatuses { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<ServicePrice> Prices { get; set; }
        public DbSet<ServiceStatus> ServicesStatuses { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<EmailType> EmailTypes { get; set; }


    }
}
