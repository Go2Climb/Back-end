using AutoMapper;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<AgencyReview> AgencyReviews { get; set; }
        public DbSet<ServiceReview> ServiceReviews { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<HiredService> HideServices { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Constrains
            //TODO: ADD PHOTO TO CUSTOMER
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(p => p.LastName).IsRequired().HasMaxLength(75);
            builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(250);
            builder.Entity<Customer>().Property(p => p.Password).IsRequired().HasMaxLength(25);
            builder.Entity<Customer>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Entity<Customer>().Property(p => p.Photo);

            //Relationship
            builder.Entity<Customer>()
                .HasMany(p => p.AgencyReviews)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
            builder.Entity<Customer>()
                .HasMany(p => p.ServiceReviews)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);
            builder.Entity<Customer>()
                .HasMany(p => p.HideServices)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            //Seed Data
            builder.Entity<Customer>().HasData
            (
                new Customer { Id = 1, Name = "Heber", LastName = "Cordova Jimenez", Email = "hbcord@gmail.com", Password = "12345", PhoneNumber = "902952757", Photo = "https://i.pinimg.com/originals/57/67/51/5767513a0191633112d3f123b3931ab6.png"},
                new Customer { Id = 2, Name = "Maria", LastName = "Cordova Jimenez", Email = "iepv@gmail.com", Password = "67890", PhoneNumber = "931015430", Photo = "https://64.media.tumblr.com/ab66cb6480d6fd36fdffbf0e76c0d706/02ec740286bff118-3b/s1280x1920/1660382d542f1cf1902bcf284fab342c44291708.png"},
                new Customer { Id = 3, Name = "Celia", LastName = "Jimenez Garcia", Email = "celia@gmail.com", Password = "12345", PhoneNumber = "977453221", Photo = "https://64.media.tumblr.com/da0f572d2a8c2d081185b443c5552c7b/9d6ea44a3722ffa2-bd/s1280x1920/0f0486280de0e7979f5482f176c2daa1edfd4a41.jpg" },
                new Customer { Id = 4, Name = "Alejandro", LastName = "Jacobo", Email = "alej@outlook.es", Password = "#o9L2TtFd", PhoneNumber = "985389026", Photo = "https://i.pinimg.com/736x/29/52/d7/2952d7689d9f57747800fc3547c3b263.jpg" },
                new Customer { Id = 5, Name = "Rem", LastName = "Milla", Email = "rem@hotmail.com", Password = "R3mbest0waif%", PhoneNumber = "952684755", Photo = "https://64.media.tumblr.com/12642d704d69eb217bd5f388f5e55688/4565013b9e16e009-ec/s500x750/da633f0ba17116f35c0f627ff6ddc44c3568bf84.png" }
            );
            
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
            //this table don't have relationships with other classes.
            
            //Seed Data
            builder.Entity<AgencyReview>().HasData
            (
                new AgencyReview {AgencyId = 1, CustomerId = 2, Id = 1, Date = "September 2021", Comment = "I had a good experience with this service.", ProfessionalismScore = 5, SecurityScore = 5, QualityScore = 5, CostScore = 5 },
                new AgencyReview {AgencyId = 2, CustomerId = 1, Id = 2, Date = "December 2020", Comment = "It is not my first time with TravelNew, they never disappoint me", ProfessionalismScore = 4, SecurityScore = 3, QualityScore = 4.5, CostScore = 3},
                new AgencyReview {AgencyId = 1, CustomerId = 4, Id = 3, Date = "November 2021", Comment = "I am satisfied with this agency, the treatment is friendly and its staff is highly trained to serve the public.", ProfessionalismScore = 5, SecurityScore = 5, QualityScore = 5, CostScore = 5},
                new AgencyReview {AgencyId = 1, CustomerId = 5, Id = 4, Date = "August 2020", Comment = "Thanks for everything, your service is too good, and the prices are worth it.", ProfessionalismScore = 5, SecurityScore = 5, QualityScore = 5, CostScore = 5}
            );
            
            //Constrains
            builder.Entity<ServiceReview>().ToTable("ServiceReviews");
            builder.Entity<ServiceReview>().HasKey(p => p.Id);
            builder.Entity<ServiceReview>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ServiceReview>().Property(p => p.Date).IsRequired();
            builder.Entity<ServiceReview>().Property(p => p.Comment).IsRequired().HasMaxLength(200);
            builder.Entity<ServiceReview>().Property(p => p.Score).IsRequired();

            //Relationships
            //does not need relationships

            //Seed Data
            builder.Entity<ServiceReview>().HasData
            (
                new ServiceReview {ServiceId = 1, CustomerId = 2, Id = 1, Date = "January 2021", Comment = "I love this agency <3.", Score = 5 },
                new ServiceReview {ServiceId = 2, CustomerId = 3, Id = 2, Date = "February 2021", Comment = "I hate this bro...", Score = 1 },
                new ServiceReview {ServiceId = 1, CustomerId = 1, Id = 3, Date = "March 2021", Comment = "I want to travel, but I cannot because there is a pandemy in the world...", Score = 3 },
                new ServiceReview {ServiceId = 1, CustomerId = 5, Id = 4, Date = "February 2021", Comment = "It is unfortunate the way in which they sell you the experience and what they end up giving you", Score = 1 }
            );

            //Agency Entity
            builder.Entity<Agency>().ToTable("Agencies");
            builder.Entity<Agency>().HasKey(p => p.Id);
            builder.Entity<Agency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Agency>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Agency>().Property(p => p.Email).IsRequired();
            builder.Entity<Agency>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(9);
            builder.Entity<Agency>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Entity<Agency>().Property(p => p.Location).IsRequired().HasMaxLength(30);
            builder.Entity<Agency>().Property(p => p.Ruc).IsRequired();
            builder.Entity<Agency>().Property(p => p.Photo);
            builder.Entity<Agency>().Property(p => p.Score);

            builder.Entity<Agency>()
                .HasMany(p => p.Services)
                .WithOne(p => p.Agency)
                .HasForeignKey(p => p.AgencyId);
            builder.Entity<Agency>()
                .HasMany(p => p.AgencyReviews)
                .WithOne(p => p.Agency)
                .HasForeignKey(p => p.AgencyId);

            builder.Entity<Agency>().HasData
            (
                new Agency { Id = 1, Name = "NewTravel", Description = "The best agency from Peru", Email = "newtravel@gmail.com", Location = "Italy, Two -Peru", Password = "123456", Photo = "https://images-platform.99static.com/lXSSpmvn5jKysOcYlarTvztFwDs=/197x100:999x902/500x500/top/smart/99designs-contests-attachments/86/86291/attachment_86291786", Ruc = "745123685", PhoneNumber = "985479265", Score = 5},
                new Agency { Id = 2, Name = "PeruT", Description = "Low prices for poor families", Email = "peruT@gmail.com", Location = "San Miguel, Lima - Peru", Password = "1234", Photo = "https://i.pinimg.com/originals/eb/e2/93/ebe293d16ad3f09d27b0164e542036fd.png", Ruc = "798456123", PhoneNumber = "974563210", Score = 4},
                new Agency { Id = 3, Name = "PeruM", Description = "From Peru to the world", Email = "peruM@gmail.com", Location = "Santa Anita, Lima - Peru", Password = "12345", Photo = "https://images-platform.99static.com/ukhjoOpwhfCFP4UuY1fVO8Me9Ns=/0x0:1776x1776/500x500/top/smart/99designs-contests-attachments/86/86123/attachment_86123519", Ruc = "852147963", PhoneNumber = "963258741", Score = 3}
            );
            //Activity Entity
            builder.Entity<Activity>().ToTable("Activities");
            builder.Entity<Activity>().HasKey(p => p.Id);
            builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Activity>().Property(p => p.Name);
            builder.Entity<Activity>().Property(p => p.Description).IsRequired().HasMaxLength(50);

            builder.Entity<Activity>().HasData
            (
                new Activity { Id = 1, Name = "activity1", Description = "description1", ServiceId = 1},
                new Activity { Id = 2, Name = "activity2", Description = "description2", ServiceId = 1},
                new Activity { Id = 3, Name = "activity2", Description = "description1", ServiceId = 2},
                new Activity { Id = 4, Name = "activity2", Description = "description2", ServiceId = 2}
            );
            //Service Entity
            builder.Entity<Service>().ToTable("Services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Entity<Service>().Property(p => p.Score);
            builder.Entity<Service>().Property(p => p.Price).IsRequired();
            builder.Entity<Service>().Property(p => p.NewPrice);
            builder.Entity<Service>().Property(p => p.Location).IsRequired();
            builder.Entity<Service>().Property(p => p.CreationDate).IsRequired();
            builder.Entity<Service>().Property(p => p.Photos);
            builder.Entity<Service>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            builder.Entity<Service>().Property(p => p.IsOffer);

            builder.Entity<Service>()
                .HasMany(p => p.Activities)
                .WithOne(p => p.Service)
                .HasForeignKey(p => p.ServiceId);
            builder.Entity<Service>()
                .HasMany(p => p.ServiceReviews)
                .WithOne(p => p.Service)
                .HasForeignKey(p => p.ServiceId);
            
            builder.Entity<Service>().HasData
            (
                new Service { Id = 1, AgencyId = 1, Name = "Enjoy an adventure in the mountains", Score = 4, Price = 480, Location = "Pomabamba, Ancash", CreationDate = "25-05-2020", Photos = "https://cdn.aarp.net/content/dam/aarp/tourism/national/2017/10/1140-maroon-bells-mountains-north-america-esp.imgcache.rev3ae52edfa9863c5cf8680f82006b8b2d.web.900.513.jpg", Description = "This is the description of this service", IsOffer = false},
                new Service { Id = 2, AgencyId = 2, Name = "Climb, luck if you survive", Score = 5, Price = 520, NewPrice = 400, Location = "LugarX, Ancash", CreationDate = "10-02-2020", Photos = "https://www.caracteristicas.co/wp-content/uploads/2018/11/montan%CC%83as-e1543190126108.jpg", Description = "This is the description of service 2", IsOffer = true},
                new Service { Id = 3, AgencyId = 3, Name = "Let's see come and enjoy this place", Score = 4, Price = 250, Location = "No, Lima", CreationDate = "20-06-2021", Photos = "https://estaticos.muyinteresante.es/media/cache/1140x_thumb/uploads/images/gallery/5f96c5745bafe85c04aac28e/1-monte-everest_1.jpg", Description = "Take home, take home", IsOffer = false},
                new Service { Id = 4, AgencyId = 1, Name = "Last chance to travel", Score = 2, Price = 780, NewPrice = 600, Location = "LugarX, Lima", CreationDate = "20-06-2021", Photos = "https://cdn.aarp.net/content/dam/aarp/travel/Domestic/2013-04/1140-wildflowers-mount-rainier-washington-frommers-beautiful-mountains-esp.imgcache.rev0e36c9680e5843406394b38ea8826513.jpg", Description = "A new place every day, come and find out for yourself", IsOffer = true}
            );

            //Constrains
            builder.Entity<HiredService>().ToTable("HiredServices");
            builder.Entity<HiredService>().HasKey(p => p.Id);
            builder.Entity<HiredService>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HiredService>().Property(p => p.Amount).IsRequired();
            builder.Entity<HiredService>().Property(p => p.Price).IsRequired();
            builder.Entity<HiredService>().Property(p => p.ScheduledDate).IsRequired().HasMaxLength(15);
            builder.Entity<HiredService>().Property(p => p.Status).IsRequired().HasMaxLength(30);

            builder.Entity<HiredService>().HasData
            (
                new HiredService {Id = 1, CustomerId = 1, ServiceId = 1, Amount = 1, Price = 480, ScheduledDate = "20/11/2021", Status = "pending"},
                new HiredService {Id = 2, CustomerId = 1, ServiceId = 2, Amount = 1, Price = 300, ScheduledDate = "14/09/2021", Status = "pending"},
                new HiredService {Id = 3, CustomerId = 5, ServiceId = 1, Amount = 3, Price = 550, ScheduledDate = "21/03/2021", Status = "finished"},
                new HiredService {Id = 4, CustomerId = 3, ServiceId = 2, Amount = 2, Price = 320, ScheduledDate = "20/09/2021", Status = "active"},
                new HiredService {Id = 5, CustomerId = 4, ServiceId = 1, Amount = 1, Price = 320, ScheduledDate = "20/11/2020", Status = "finished"}
            );
            
            builder.UseSnakeCaseNamingConventions();
        }
        
    }
}