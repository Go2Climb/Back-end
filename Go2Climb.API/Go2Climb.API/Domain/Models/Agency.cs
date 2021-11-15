using System.Collections.Generic;

namespace Go2Climb.API.Domain.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Ruc { get; set; }
        public string Photo { get; set; }
        public int Score { get; set; }
        public IList<Service> Services { get; set; }
        public IList<AgencyReview> AgencyReviews { get; set; }
    }
}