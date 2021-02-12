using AutoMapper;
using ControllerApp.Domains.Cars;
using ControllerApp.Domains.Users;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Cars;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControllerApp.Services
{
    public class CarBookingService : ICarBookingInterface
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IUserInterface _userInterface;

        public CarBookingService(DatabaseContext databaseContext, IMapper mapper, IUserInterface userInterface)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _userInterface = userInterface;
        }

        public CarBooking AddCarBooking(TempCarBooking tempCarBooking)
        {
            var carBooking = new CarBooking();
            var user = _userInterface.GetUserByEmail(tempCarBooking.User.Email);
            var car = getCarByRegistrationNumber(tempCarBooking.Car.RegistrationNumber);

            if (user != null)
            {
                carBooking.User = user;
                carBooking.UserId = user.UserId;
            }
            else
            {
                tempCarBooking.User.UserTypeId = (int)UserTypes.System;
                tempCarBooking.User.DateOfBirth = DateTime.Now;
                carBooking.User = _userInterface.AddUser(tempCarBooking.User);
                carBooking.UserId = carBooking.User.UserId;
            }

            if (car != null)
            {
                carBooking.Car = car;
                carBooking.CarId = car.CarId;
            }
            else
            {
                carBooking.Car = AddCar(tempCarBooking.Car);
                carBooking.CarId = carBooking.Car.CarId;
            }

            carBooking.BookingReason = tempCarBooking.BookingReason;
            carBooking.BookingFrom = tempCarBooking.BookingFrom;
            carBooking.BookingTo = tempCarBooking.BookingTo;
            carBooking.CarId = tempCarBooking.Car.CarId;

            carBooking.DateCaptured = DateTime.Now;
            carBooking.UserCatured = carBooking.UserId;

            _databaseContext.CarBookings.Add(carBooking);
            _databaseContext.SaveChanges();

            carBooking.ReferenceNo = "CB" + carBooking.CarBookingId;
            _databaseContext.SaveChanges();
            return carBooking;
        }

        public List<Car> GetCars()
        {
            return _databaseContext.Cars.ToList();
        }

        public Car AddCar(TempCar tempCar)
        {
            var car = new Car
            {
                RegistrationNumber = tempCar.RegistrationNumber,
            };

            car.DateCaptured = DateTime.Now;
            _databaseContext.Cars.Add(car);
            _databaseContext.SaveChanges();

            return car;
        }

        public Car getCarByRegistrationNumber(string registrationNumber)
        {
            return _databaseContext.Cars.Where(c => c.RegistrationNumber == registrationNumber).FirstOrDefault();
        }

        public Car getCarById(int id)
        {
            return _databaseContext.Cars.Find(id);
        }

        public List<CarBooking> GetCarBookings()
        {
            return _databaseContext.CarBookings
                .Include(cb => cb.Car)
                .Include(cb => cb.User).ToList();
        }

        public CarBooking GetCarBooking(int id)
        {
            return _databaseContext.CarBookings.Find(id);
        }

        public void updateBooking(TempCarBooking tempCarBooking)
        {
            var carBooking = _databaseContext.CarBookings.Find(tempCarBooking.CarBookingId);

            carBooking.BookingReason = tempCarBooking.BookingReason;
            carBooking.BookingFrom = tempCarBooking.BookingFrom;
            carBooking.BookingTo = tempCarBooking.BookingTo;
            carBooking.CarId = tempCarBooking.CarId;
            carBooking.UserId = tempCarBooking.UserId;

            carBooking.DateCaptured = DateTime.Now;
            _databaseContext.SaveChanges();
        }
    }
}
