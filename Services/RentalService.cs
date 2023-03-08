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

        public void RentalCar(RentalDTO rental, int carId, int locationId)
        {
            throw new NotImplementedException();
        }

        public void ReturnCar(RentalDTO rental, int carId, int locationtId)
        {
            throw new NotImplementedException();
        }
    }
}
