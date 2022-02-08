using Domain.Entities;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence
{
    public class BaseDbContext:DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration):base(dbContextOptions)
        {
            Configuration = configuration;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { 
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(b =>
            {
                b.ToTable("Models").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                b.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                b.Property(p => p.BrandId).HasColumnName("BrandId");
                b.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
                b.Property(p => p.FuelId).HasColumnName("FuelId");
                b.HasOne(p => p.Transmission);
                b.HasOne(p => p.Fuel);
                b.HasOne(p => p.Brand);
                b.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Color>(b =>
            {
                b.ToTable("Colors").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Cars);
            });

            modelBuilder.Entity<Fuel>(b =>
            {
                b.ToTable("Fuels").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Transmission>(b =>
            {
                b.ToTable("Transmissions").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Car>(b =>
            {
                b.ToTable("Cars").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.ModelYear).HasColumnName("ModelYear");
                b.Property(p => p.Plate).HasColumnName("Plate");
                b.Property(p => p.ColorId).HasColumnName("ColorId");
                b.Property(p => p.ModelId).HasColumnName("ModelId");
                b.Property(p => p.CarState).HasColumnName("State");
                b.Property(p => p.FindexScore).HasColumnName("FindexScore");
                b.HasMany(p => p.Rentals);
                b.HasOne(p => p.Color);
                b.HasOne(p => p.Model);
            });

            modelBuilder.Entity<Rental>(b =>
            {
                b.ToTable("Rentals").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.RentDate).HasColumnName("RentDate");
                b.Property(p => p.ReturnDate).HasColumnName("ReturnDate");
                b.Property(p => p.RentKilometer).HasColumnName("RentKilometer");
                b.Property(p => p.ReturnKilometer).HasColumnName("ReturnKilometer");
                b.Property(p => p.CarId).HasColumnName("CarId");
                b.Property(p => p.CustomerId).HasColumnName("CustomerId");
                b.HasOne(p => p.Car);
                b.HasOne(p => p.Customer);
            });

            modelBuilder.Entity<Maintenance>(b =>
            { 
                b.ToTable("Maintenances").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Description).HasColumnName("Description");
                b.Property(p => p.MaintenanceDate).HasColumnName("MaintenanceDate");
                b.Property(p => p.ReturnDate).HasColumnName("ReturnDate");
                b.Property(p => p.CarId).HasColumnName("CarId");
                b.HasOne(p => p.Car);

            });

            modelBuilder.Entity<Customer>(b =>
            {
                b.ToTable("Customers").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Email).HasColumnName("Email");
                b.HasOne(p => p.IndividualCustomer);
                b.HasOne(p => p.CorporateCustomer);
                b.HasMany(p => p.Rentals);
            });

            modelBuilder.Entity<CorporateCustomer>(b =>
            {
                b.ToTable("CorporateCustomers");
                b.Property(p => p.CustomerId).HasColumnName("CustomerId");
                b.Property(p => p.CompanyName).HasColumnName("CompanyName");
                b.Property(p => p.TaxId).HasColumnName("TaxId");
                b.HasOne(p => p.Customer);
            });

            modelBuilder.Entity<IndividualCustomer>(b =>
            {
                b.ToTable("IndividualCustomers");
                b.Property(p => p.CustomerId).HasColumnName("CustomerId");
                b.Property(p => p.FirstName).HasColumnName("CompanyName");
                b.Property(p => p.LastName).HasColumnName("LastName");
                b.Property(p => p.NationalityId).HasColumnName("NationalityId");
                b.HasOne(p => p.Customer);
            });

            modelBuilder.Entity<Invoice>(b =>
            {
                b.ToTable("Invoices");
                b.Property(p => p.Id).HasColumnName("id");
                b.Property(p => p.CustomerId).HasColumnName("CustomerId");
                b.Property(p => p.RentalId).HasColumnName("RentalId");
                b.Property(p => p.InvoiceNumber).HasColumnName("InvoiceNumber");
                b.Property(p => p.InvoicedDate).HasColumnName("InvoicedDate");
                b.Property(p => p.TotalRentalDate).HasColumnName("TotalRentalDate");
                b.Property(p => p.TotalPrice).HasColumnName("TotalPrice");
            });

            var brand1 = new Brand(1, "BMW");
            var brand2 = new Brand(2, "Mercedes");
            modelBuilder.Entity<Brand>().HasData(brand1,brand2);

            var color1 = new Color(1, "Red");
            var color2 = new Color(2, "Blue");
            modelBuilder.Entity<Color>().HasData(color1, color2);

            var transmission1 = new Transmission(1, "Manuel");
            var transmission2 = new Transmission(2, "Automatic");
            modelBuilder.Entity<Transmission>().HasData(transmission1, transmission2);

            var fuel1 = new Fuel(1, "Disel");
            var fuel2 = new Fuel(2, "Electric");
            modelBuilder.Entity<Fuel>().HasData(fuel1, fuel2);

            var model1 = new Model(1, "418i", 1000, 2, 1, 1, "https://images.pexels.com/photos/170811/pexels-photo-170811.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500");
            var model2 = new Model(2, "CLA 180D", 600, 2, 1, 2, "");
            modelBuilder.Entity<Model>().HasData(model1, model2);

            var car1 = new Car(1, 1, 1,"06ABC06", 2018, CarState.Available,1750);
            var car2 = new Car(2, 2, 2, "34ABC34", 2018, CarState.Available,1520);
            modelBuilder.Entity<Car>().HasData(car1, car2);

 
        }

    }
}