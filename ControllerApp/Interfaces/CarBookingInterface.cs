using ControllerApp.TempModels.Cars;
using System.Collections.Generic;

namespace ControllerApp.Interfaces
{
    public interface ICarBookingInterface
    {
        List<TempCar> GetCars();
    }
}
