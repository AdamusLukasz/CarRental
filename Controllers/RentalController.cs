using CarRental.DTOs;
using CarRental.Entities;
using CarRental.Services.ServiceInterfaces;
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

        [HttpPost("rentCar")]
        public ActionResult<Rental> RentCar([FromQuery] RentalPostDTO rent)
        {
            _rentalService.RentCar(rent);

            return Ok();
        }

        [HttpPost("returnCar")]
        public ActionResult<Rental> ReturnCar([FromQuery]int carId, int locationId)
        {
            _rentalService.ReturnCar(carId, locationId);

            return Ok();
        }
    }
}
