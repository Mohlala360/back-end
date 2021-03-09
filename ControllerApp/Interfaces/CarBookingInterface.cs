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
        Car GetCarByRegistrationNumber(string registrationNumber);
        Car GetCarById(int id);
        List<CarBooking> GetCarBookings();
        CarBooking GetCarBooking(int id);
        void UpdateBooking(TempCarBooking tempCarBooking);
        void BookOutOrBackCar(int carBookingId, int stateId);
        List<CarBookStatus> GetBookStatuses();
    }
}
