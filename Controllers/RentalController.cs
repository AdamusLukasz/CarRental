using CarRental.DTOs;
using CarRental.Entities;
using CarRental.Services.ServiceIntervaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/rentals/")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public ActionResult<Rental> GetAvailableCars()
        {
            var rents = _rentalService.GetAll();
            return Ok(rents);
        }

        [HttpPost("rentalCar")]
        public ActionResult<Rental> RentalCar([FromQuery] RentalDTO rent, int carId, int locationId)
        {
            _rentalService.RentalCar(rent, carId, locationId);

            return Ok();
        }
    }
}
