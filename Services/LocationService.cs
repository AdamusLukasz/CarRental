using CarRental.DTOs;
using CarRental.Entities;
using CarRental.Services.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services
{
    public class LocationService : ILocationService
    {
        private readonly CarRentalDbContext _dbContext;

        public LocationService(CarRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<LocationDTO> GetAirports()
        {
            var cars = _dbContext.Locations
                .Include(a => a.Cars)
                .Select(a => LocationDTO.ToAirportDTOMap(a))
                .ToList();

            return cars;
        }
    }
}