using CarRental.DTOs;
using CarRental.Entities;
using CarRental.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly CarRentalDbContext _dbContext;

        public RentalService(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RentalDTO> GetAll()
        {
            var rentals = _dbContext.Rentals
                .Select(a => RentalDTO.ToRentDTOMap(a))
                .ToList();

            return rentals;
        }

        public void RentCar(RentalPostDTO rent)
        {
            var location = FindLocation(rent.IdOfRentalLocation);

            var car = location.Cars.FirstOrDefault(a => a.Id == rent.IdOfRentalCar);

            if (car.AvailabilityCount == 0)
            {
                throw new Exception("That car is not available.");
            }

            car.AvailabilityCount--;

            var newRental = new Rental
            {
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                CarId = car.Id,
                LocationId = location.Id
            };

            var rentalDays = (int)(newRental.EndDate - newRental.StartDate).TotalDays;

            newRental.RentalPrice = rentalDays * car.RentalPricePerDay;

            _dbContext.Rentals.Add(newRental);
            _dbContext.SaveChanges();
        }

        public void ReturnCar(int carId, int locationId)
        {
            var location = FindLocation(locationId);

            var car = location.Cars.FirstOrDefault(a => a.Id == carId);

            car.AvailabilityCount++;
            _dbContext.SaveChanges();
        }

        private Location FindLocation(int locationId)
        {
            return _dbContext.Locations
                    .Include(a => a.Cars)
                    .FirstOrDefault(a => a.Id == locationId);
        }
    }
}
