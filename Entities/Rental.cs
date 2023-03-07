namespace CarRental.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdOfRentalCar { get; set; }
        public int IdOfRentalLocation { get; set; }
    }
}
