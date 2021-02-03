using AutoMapper;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Cars;
using System.Collections.Generic;
using System.Linq;

namespace ControllerApp.Services
{
    public class CarBookingService : ICarBookingInterface
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public CarBookingService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public List<TempCar> GetCars()
        {
            var cars = _databaseContext.Cars.ToList();
            return _mapper.Map<List<TempCar>>(cars);
        }
    }
}
