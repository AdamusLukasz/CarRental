using CarRental.DTOs;
using CarRental.Entities;
using CarRental.Services.ServiceIntervaces;
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

        public void RentalCar(RentalDTO rent, int carId, int locationId)
        {
            var location = _dbContext.Locations
                .Include(a => a.Cars)
                .FirstOrDefault(a => a.Id == locationId);

            var car = location.Cars.FirstOrDefault(a => a.Id == carId);

            if (car.AvailabilityCount == 0)
            {
                throw new Exception("That car is not available.");
            }

            car.AvailabilityCount--;

            var newRental = new Rental
            {
                StartDate = rent.StartDate,
                EndDate = rent.EndDate,
                IdOfRentalCar = car.Id,
                IdOfRentalLocation = location.Id
            };

            _dbContext.Rentals.Add(newRental);
            _dbContext.SaveChanges();
        }

        public void ReturnCar(RentalDTO rental, int carId, int locationtId)
        {
            throw new NotImplementedException();
        }
    }
}
