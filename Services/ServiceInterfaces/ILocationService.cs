using CarRental.DTOs;

namespace CarRental.Services.ServiceInterfaces
{
    public interface ILocationService
    {
        IEnumerable<LocationDTO> GetAirports();
    }
}