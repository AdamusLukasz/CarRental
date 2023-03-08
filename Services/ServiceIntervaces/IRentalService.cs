using CarRental.DTOs;

namespace CarRental.Services.ServiceIntervaces
{
    public interface IRentalService
    {
        IEnumerable<RentalDTO> GetAll();
        void RentalCar(RentalDTO rental, int carId, int locationId);
        void ReturnCar(RentalDTO rental, int carId, int locationtId);
    }
}
