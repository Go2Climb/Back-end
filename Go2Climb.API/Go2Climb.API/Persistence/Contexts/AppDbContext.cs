using Go2Climb.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<AgencyReview> ReviewAgencies { get; set; }
        public DbSet<ServiceReview> ReviewServices { get; set; }
        public DbSet<Customer> Customers { get; set; }

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
            //TODO: add test data to Agency reviews
    
            
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

            //Constrains
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(p => p.LastName).IsRequired().HasMaxLength(75);
            builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(250);
            builder.Entity<Customer>().Property(p => p.Password).IsRequired().HasMaxLength(25);
            builder.Entity<Customer>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
            
            //Relationship
            builder.Entity<Customer>()
                .HasMany(p => p.AgencyReviews)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
            builder.Entity<Customer>()
                .HasMany(p => p.ServiceReviews)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
            
            //Seed Data
            builder.Entity<Customer>().HasData
            (
                new Customer { Id = 1, Name = "Heber", LastName = "Cordova Jimenez", Email = "hbcordova10@gmail.com", Password = "12345", PhoneNumber = "902952757" },
                new Customer { Id = 2, Name = "Maria", LastName = "Cordova Jimenez", Email = "iepvcordova@gmail.com", Password = "67890", PhoneNumber = "931015430" },
                new Customer { Id = 3, Name = "Celia", LastName = "Jimenez Garcia", Email = "celia@gmail.com", Password = "12345", PhoneNumber = "977453221" }
            );
            
        }
        
    }
}