using CarRental.Entities;

namespace CarRental.DTOs
{
    public class LocationDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarDTO> Cars { get; set; }

        public static LocationDTO ToAirportDTOMap(Location location)
        {
            return new LocationDTO 
            { 
                Id = location.Id,
                Name = location.Name,
                Cars = ToCarDTOMap(location.Cars)
            };
        }

        public static IEnumerable<CarDTO> ToCarDTOMap(IEnumerable<Car> cars)
        {
            var carsDtos = new List<CarDTO>();
            foreach (var car in cars)
            {
                carsDtos.Add(new CarDTO()
                {
                    Id = car.Id,
                    Name = car.Name,
                    AvailabilityCount = car.AvailabilityCount
                });
            }

            return carsDtos;
        }
    }
}