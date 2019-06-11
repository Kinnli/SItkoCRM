using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SitkoCRM.Models
{
    public class Services : BaseModel
    {
        [Key] public int ServiceId { get; set; }

        public DateTime ActiveTo { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")] public Clients Client { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("StatusId")] public ServicesStatuses Status { get; set; }

        public int PriceId { get; set; }

        [ForeignKey("PriceId")] public ServicesPrices Price { get; set; }

        public List<Hosts> Hosts { get; set; }
        public List<DomainsServices> DomainsServices { get; set; }
        public List<Bills> Bills { get; set; }
    }
}