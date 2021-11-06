namespace Go2Climb.API.Domain.Models
{
    public class AgencyReview
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public short ProfessionalismScore { get; set; }
        public short SecurityScore { get; set; }
        public short QualityScore { get; set; }
        public short CostScore { get; set; }

        //Relationships
        public string AgencyId { get; set; }
        //  public Agency Agency { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}