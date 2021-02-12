using ControllerApp.Domains.Cars;
using ControllerApp.TempModels.Cars;
using System.Collections.Generic;

namespace ControllerApp.Interfaces
{
    public interface ICarBookingInterface
    {
        List<Car> GetCars();
        CarBooking AddCarBooking(TempCarBooking tempCarBooking);
        Car AddCar(TempCar tempCar);
        Car getCarByRegistrationNumber(string registrationNumber);
        Car getCarById(int id);
        List<CarBooking> GetCarBookings();
        CarBooking GetCarBooking(int id);
        void updateBooking(TempCarBooking tempCarBooking);
    }
}
