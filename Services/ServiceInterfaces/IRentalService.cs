using CarRental.DTOs;

namespace CarRental.Services.ServiceInterfaces
{
    public interface IRentalService
    {
        IEnumerable<RentalDTO> GetAll();
        void RentCar(RentalPostDTO rent);
        void ReturnCar(int carId, int locationtId);
    }
}
