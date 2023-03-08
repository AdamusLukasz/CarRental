using CarRental.Entities;
using CarRental.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/locations")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public ActionResult<Location> GetAvailableCars()
        {
            var airports = _locationService.GetAirports();
            return Ok(airports);
        }
    }
}