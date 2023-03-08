using CarRental.Entities;


namespace CarRental.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailabilityCount { get; set; }


        public static CarDTO ToCarDTOMap(Car car)
        {
            return new CarDTO()
            {
                Id = car.Id,
                Name = car.Name,
                AvailabilityCount = car.AvailabilityCount,
            };
        }
    }
}