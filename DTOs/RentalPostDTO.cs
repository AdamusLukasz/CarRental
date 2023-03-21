﻿using CarRental.Entities;

namespace CarRental.DTOs
{
    public class RentalPostDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdOfRentalCar { get; set; }
        public int IdOfRentalAirport { get; set; }

        public static RentalPostDTO ToRentalPostDTOMap(Rental rental)
        {
            return new RentalPostDTO()
            {
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                IdOfRentalCar = rental.IdOfRentalCar,
                IdOfRentalAirport = rental.IdOfRentalLocation
            };
        }
    }
}
