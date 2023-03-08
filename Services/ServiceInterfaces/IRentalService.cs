using CarRental.DTOs;

namespace CarRental.Services.ServiceInterfaces
{
    public interface IRentalService
    {
        IEnumerable<RentalDTO> GetAll();
        void RentalCar(RentalDTO rental, int carId, int locationId);
        void ReturnCar(int carId, int locationtId);
    }
}
