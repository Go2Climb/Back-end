using System.Collections.Generic;

namespace Go2Climb.API.Domain.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Score { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public string Location { get; set; }
        public string CreationDate { get; set; }
        public List<string>Photos { get; set; }
        public string Description { get; set; }
        public bool IsOffer { get; set; }
        
        // Relationships
        
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}