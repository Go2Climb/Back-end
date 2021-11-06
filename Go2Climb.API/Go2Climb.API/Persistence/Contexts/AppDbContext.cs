using AutoMapper;
using Go2Climb.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<AgencyReview> ReviewAgencies { get; set; }
        public DbSet<ServiceReview> ReviewServices { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Service> Services { get; set; }
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

            builder.Entity<Agency>().HasData
            (
                new Agency { Id = 1, Name = "NewTravel", Description = "The best agency from Peru", Email = "newtravel@gmail.com", Location = "Italy, Two -Peru", Password = "123456", Photo = "https://www.paquetesdeviajesperu.com/wp-content/uploads/2021/10/logo-peru-grand-travel-1.png", Ruc = "745123685", PhoneNumber = "985479265", Score = 5},
                new Agency { Id = 2, Name = "PeruT", Description = "Low prices for poor families", Email = "peruT@gmail.com", Location = "San Miguel, Lima - Peru", Password = "1234", Photo = "https://www.paquetesdeviajesperu.com/wp-content/uploads/2021/10/logo-peru-grand-travel-1.png", Ruc = "798456123", PhoneNumber = "974563210", Score = 4},
                new Agency { Id = 3, Name = "PeruM", Description = "From Peru to the world", Email = "peruM@gmail.com", Location = "Santa Anita, Lima - Peru", Password = "12345", Photo = "https://www.paquetesdeviajesperu.com/wp-content/uploads/2021/10/logo-peru-grand-travel-1.png", Ruc = "852147963", PhoneNumber = "963258741", Score = 3}
            );
            //Activity Entity
            builder.Entity<Activity>().ToTable("Activities");
            builder.Entity<Activity>().HasKey(p => p.Id);
            builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Activity>().Property(p => p.Name);
            builder.Entity<Activity>().Property(p => p.Description).IsRequired().HasMaxLength(50);

            builder.Entity<Activity>()
                .HasOne(p => p.Service)
                .WithMany(p => p.Activities)
                .HasForeignKey(p => p.ServiceId);

            builder.Entity<Activity>().HasData
            (
                new Activity { Id = 1, Name = "activity1", Description = "description1", ServiceId = 1},
                new Activity { Id = 2, Name = "activity2", Description = "description2", ServiceId = 1},
                new Activity { Id = 1, Name = "activity2", Description = "description1", ServiceId = 2},
                new Activity { Id = 2, Name = "activity2", Description = "description2", ServiceId = 2}
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

            builder.Entity<Service>().HasData
            (
                new Service { Id = 1, AgencyId = 1, Name = "Enjoy an adventure in the mountains", Score = 4, Price = 480, Location = "Pomabamba, Ancash", CreationDate = "25-05-2020", Photos = "https://cdn.aarp.net/content/dam/aarp/tourism/national/2017/10/1140-maroon-bells-mountains-north-america-esp.imgcache.rev3ae52edfa9863c5cf8680f82006b8b2d.web.900.513.jpg", Description = "This is the description of this service", IsOffer = false},
                new Service { Id = 2, AgencyId = 1, Name = "Climb, luck if you survive", Score = 5, Price = 520, NewPrice = 400, Location = "LugarX, Ancash", CreationDate = "10-02-2020", Photos = "https://www.caracteristicas.co/wp-content/uploads/2018/11/montan%CC%83as-e1543190126108.jpg", Description = "This is the description of service 2", IsOffer = true},
                new Service { Id = 3, AgencyId = 3, Name = "Let's see come and enjoy this place", Score = 4, Price = 250, Location = "No, Lima", CreationDate = "20-06-2021", Photos = "https://estaticos.muyinteresante.es/media/cache/1140x_thumb/uploads/images/gallery/5f96c5745bafe85c04aac28e/1-monte-everest_1.jpg", Description = "Take home, take home", IsOffer = false},
                new Service { Id = 4, AgencyId = 3, Name = "Last chance to travel", Score = 2, Price = 780, NewPrice = 600, Location = "LugarX, Lima", CreationDate = "20-06-2021", Photos = "https://cdn.aarp.net/content/dam/aarp/travel/Domestic/2013-04/1140-wildflowers-mount-rainier-washington-frommers-beautiful-mountains-esp.imgcache.rev0e36c9680e5843406394b38ea8826513.jpg", Description = "A new place every day, come and find out for yourself", IsOffer = true}
            );
        }
        
    }
}