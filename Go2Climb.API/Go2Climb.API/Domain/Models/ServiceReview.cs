﻿namespace Go2Climb.API.Domain.Models
{
    public class ServiceReview
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; } 
        public short Score { get; set; }
        
        //Relationships
        public string ServiceId { get; set; } 
        //  public Service service { get; set; }
        public string CustomerId { get; set; }
        //  public Customer Customer { get; set; }
    }
}