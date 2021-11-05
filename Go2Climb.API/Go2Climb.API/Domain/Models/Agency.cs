using System.Collections.Generic;

namespace Go2Climb.API.Domain.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Ruc { get; set; }
        public string Photo { get; set; }

        public List<Service> Services { get; set; } = new List<Service>();
    }
}