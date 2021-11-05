﻿using System.Collections.Generic;

namespace Go2Climb.API.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<AgencyReview> AgencyReviews { get; set; } = new List<AgencyReview>();
        public List<ServiceReview> ServiceReviews { get; set; } = new List<ServiceReview>();
        public List<HideService> HideServices { get; set; } = new List<HideService>();
    }
}