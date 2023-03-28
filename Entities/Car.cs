namespace CarRental.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailabilityCount { get; set; }
        public int RentalPricePerDay { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
