using System.ComponentModel.DataAnnotations.Schema;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Models
{
    [Table("ClientContacts")]
    public class ClientContact : BaseModel<int>
    {
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public int ClientId { get; set; }

        [ForeignKey(nameof(ClientId))] public Client Client { get; set; }
    }

    public class ClientContactsRepository : Repository<ClientContact, int, CRMContainer>
    {
        public ClientContactsRepository(RepositoryContext<ClientContact, int, CRMContainer> repositoryContext) : base(
            repositoryContext)
        {
        }
    }
}
