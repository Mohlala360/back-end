using ControllerApp.Domains.Cars;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Cars;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ControllerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarBookingController : ControllerBase
    {
        public readonly ICarBookingInterface _carBookingInterface;
        public readonly IUserInterface _userInterface;

        public CarBookingController(ICarBookingInterface carBookingInterface, IUserInterface userInterface)
        {
            _carBookingInterface = carBookingInterface;
            _userInterface = userInterface;
        }

        [HttpGet("cars")]
        public IActionResult GetCars()
        {
            var cars = _carBookingInterface.GetCars();
            if (cars.Count == 0)
            {
                cars.Add(new Car { CarId = 1, RegistrationNumber = "Stanley GP" });

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
            var carBooking = _carBookingInterface.AddCarBooking(tempCarBooking);
            return Ok(tempCarBooking);
        }

        [HttpPut]
        public IActionResult UpdateCarBooking([FromBody] TempCarBooking tempCarBooking)
        {
            _carBookingInterface.UpdateBooking(tempCarBooking);
            return Ok(tempCarBooking);
        }

        [HttpGet]
        public IActionResult GetCarBookings()
        {
            var carBookings = _carBookingInterface.GetCarBookings();
            return Ok(carBookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarBooking(int id)
        {
            var carBooking = _carBookingInterface.GetCarBooking(id);
            carBooking.User = _userInterface.GetUser(carBooking.UserId);
            carBooking.Car = _carBookingInterface.GetCarById(carBooking.CarId);
            return Ok(carBooking);
        }

        [HttpGet("bookingStatuses")]
        public IActionResult GetBookingStatuses()
        {
            var bookingStatuses = _carBookingInterface.GetBookStatuses();
            return Ok(bookingStatuses);
        }

        [HttpPut("actionState")]
        public IActionResult ActionState(int carBookingId, int stateId)
        {
            _carBookingInterface.BookOutOrBackCar(carBookingId, stateId);
            return Ok();
        }
    }
}
