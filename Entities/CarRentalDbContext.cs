﻿using Microsoft.EntityFrameworkCore;

namespace CarRental.Entities
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
        {

        }

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>(mb =>
            {
                mb.Property(a => a.StartDate).IsRequired();
                mb.Property(a => a.EndDate).IsRequired();

                mb.HasData(new Rental { Id = 1, StartDate = new DateTime(2023, 04, 01), EndDate = new DateTime(2023, 04, 04), RentalPrice = 30, LocationId = 1, CarId = 1 });
                mb.HasData(new Rental { Id = 2, StartDate = new DateTime(2023, 04, 01), EndDate = new DateTime(2023, 04, 15), RentalPrice = 1400, LocationId = 2, CarId = 5 });
            });

            modelBuilder.Entity<Location>(mb =>
            {
                mb.Property(a => a.Name).IsRequired();

                mb.HasMany(a => a.Cars)
                .WithOne(b => b.Location)
                .HasForeignKey(c => c.LocationId);

                mb.HasData(new Location { Id = 1, Name = "Palma Airport" });
                mb.HasData(new Location { Id = 2, Name = "Palma City Center" });
                mb.HasData(new Location { Id = 3, Name = "Alcudia" });
                mb.HasData(new Location { Id = 4, Name = "Manacor" });

            });

            modelBuilder.Entity<Car>(mb =>
            {
                mb.Property(a => a.Name).IsRequired();

                mb.HasData(new Car { Id = 1, Name = "Tesla Model S", AvailabilityCount = 1, RentalPricePerDay = 10, LocationId = 1 });
                mb.HasData(new Car { Id = 2, Name = "Tesla Model 3", AvailabilityCount = 2, RentalPricePerDay = 15, LocationId = 1 });
                mb.HasData(new Car { Id = 3, Name = "Tesla Model X", RentalPricePerDay = 20, AvailabilityCount = 2, LocationId = 1 });
                mb.HasData(new Car { Id = 4, Name = "Tesla Model Y", RentalPricePerDay = 25, AvailabilityCount = 2, LocationId = 1 });
                mb.HasData(new Car { Id = 5, Name = "Tesla Model S", AvailabilityCount = 1, RentalPricePerDay = 10, LocationId = 2 });
                mb.HasData(new Car { Id = 6, Name = "Tesla Model 3", AvailabilityCount = 2, RentalPricePerDay = 15, LocationId = 2 });
                mb.HasData(new Car { Id = 7, Name = "Tesla Model X", RentalPricePerDay = 20, AvailabilityCount = 2, LocationId = 2 });
                mb.HasData(new Car { Id = 8, Name = "Tesla Model Y", RentalPricePerDay = 25, AvailabilityCount = 2, LocationId = 2 });
                mb.HasData(new Car { Id = 9, Name = "Tesla Model S", AvailabilityCount = 2, RentalPricePerDay = 10, LocationId = 3 });
                mb.HasData(new Car { Id = 10, Name = "Tesla Model 3", AvailabilityCount = 2, RentalPricePerDay = 15, LocationId = 3 });
                mb.HasData(new Car { Id = 11, Name = "Tesla Model X", RentalPricePerDay = 20, AvailabilityCount = 2, LocationId = 3 });
                mb.HasData(new Car { Id = 12, Name = "Tesla Model Y", RentalPricePerDay = 25, AvailabilityCount = 2, LocationId = 3 });
                mb.HasData(new Car { Id = 13, Name = "Tesla Model S", AvailabilityCount = 2, RentalPricePerDay = 10, LocationId = 4 });
                mb.HasData(new Car { Id = 14, Name = "Tesla Model 3", AvailabilityCount = 2, RentalPricePerDay = 15, LocationId = 4 });
                mb.HasData(new Car { Id = 15, Name = "Tesla Model X", RentalPricePerDay = 20, AvailabilityCount = 2, LocationId = 4 });
                mb.HasData(new Car { Id = 16, Name = "Tesla Model Y", RentalPricePerDay = 25, AvailabilityCount = 2, LocationId = 4 });
            });
        }
    }
}
