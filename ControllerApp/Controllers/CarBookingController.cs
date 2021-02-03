using ControllerApp.Interfaces;
using ControllerApp.TempModels.Cars;
using Microsoft.AspNetCore.Mvc;

namespace ControllerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarBookingController : ControllerBase
    {
        public readonly ICarBookingInterface _carBookingInterface;

        public CarBookingController(ICarBookingInterface carBookingInterface)
        {
            _carBookingInterface = carBookingInterface;
        }

        [HttpGet("cars")]
        public IActionResult GetCars()
        {
            var cars = _carBookingInterface.GetCars();
            if (cars.Count == 0)
            {
                cars.Add(new TempCar { CarId = 1, RegistrationNumber = "Stanley GP" });
                cars.Add(new TempCar { CarId = 2, RegistrationNumber = "Judith GP" });
                cars.Add(new TempCar { CarId = 3, RegistrationNumber = "Thuto GP" });

                return Ok(cars);
            }
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCarBooking([FromBody] TempCarBooking tempCarBooking)
        {
            if (tempCarBooking == null)
            {
                return BadRequest("User is null are you crazy");
            }
           // var u = _userInterface.AddUser(tempUser);
            return Ok(tempCarBooking);
        }
    }
}
