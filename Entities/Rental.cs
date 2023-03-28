namespace CarRental.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentalPrice { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
    }
}
