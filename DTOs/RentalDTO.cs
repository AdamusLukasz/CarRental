using CarRental.Entities;

namespace CarRental.DTOs
{
    public class RentalDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentalPrice { get; set; }
        public int IdOfRentalCar { get; set; }
        public int IdOfRentalAirport { get; set; }

        public static RentalDTO ToRentDTOMap(Rental rental)
        {
            return new RentalDTO()
            {
                Id = rental.Id,
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                RentalPrice = rental.RentalPrice,
                IdOfRentalCar = rental.CarId,
                IdOfRentalAirport = rental.LocationId
            };
        }
    }
}
