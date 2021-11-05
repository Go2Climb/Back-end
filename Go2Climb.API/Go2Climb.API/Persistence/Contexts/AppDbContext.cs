using Go2Climb.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<AgencyReview> AgencyReviews { get; set; }
        public DbSet<ServiceReview> ServiceReviews { get; set; }
        
        public AppDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Constrains
            builder.Entity<AgencyReview>().ToTable("AgencyReviews");
            builder.Entity<AgencyReview>().HasKey(p => p.Id);
            builder.Entity<AgencyReview>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<AgencyReview>().Property(p => p.Date).IsRequired();
            builder.Entity<AgencyReview>().Property(p => p.Comment).IsRequired().HasMaxLength(200);
            builder.Entity<AgencyReview>().Property(p => p.ProfessionalismScore).IsRequired();
            builder.Entity<AgencyReview>().Property(p => p.SecurityScore).IsRequired();
            builder.Entity<AgencyReview>().Property(p => p.QualityScore).IsRequired();
            builder.Entity<AgencyReview>().Property(p => p.CostScore).IsRequired();
            
            //Relationships
            //TODO: add the relationship with customer and agency to Agency reviews
            
            //Seed Data
            builder.Entity<AgencyReview>().HasData
            (
                new AgencyReview {Id = 1, Date = "September 2021", Comment = "I had a good experience with this service.", ProfessionalismScore = 5, SecurityScore = 5, QualityScore = 5, CostScore = 5},
                new AgencyReview {Id = 2, Date = "December 2020", Comment = "It is not my first time with TravelNew, they never disappoint me", ProfessionalismScore = 4, SecurityScore = 3, QualityScore = 4.5, CostScore = 3}
            );
            
            //Constrains
            builder.Entity<ServiceReview>().ToTable("ServiceReviews");
            builder.Entity<ServiceReview>().HasKey(p => p.Id);
            builder.Entity<ServiceReview>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ServiceReview>().Property(p => p.Date).IsRequired();
            builder.Entity<ServiceReview>().Property(p => p.Comment).IsRequired().HasMaxLength(200);
            builder.Entity<ServiceReview>().Property(p => p.Score).IsRequired();

            //Relationships
            //TODO: add the relationship with customer and agency to Service reviews

            //Seed Data
            //TODO: add test data to Service reviews


        }
        
    }
}