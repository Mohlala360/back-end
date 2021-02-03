using AutoMapper;
using ControllerApp.Domains.Books;
using ControllerApp.Domains.Cars;
using ControllerApp.Domains.UserBooks;
using ControllerApp.Domains.Users;
using ControllerApp.TempModels.Books;
using ControllerApp.TempModels.Cars;
using ControllerApp.TempModels.UserBooks;
using ControllerApp.TempModels.Users;
using System.Linq;

namespace ControllerApp
{
    public static class DataMapping
    {
        private static IMapper _mapper;

        public static IMapper CreateMappers()
        {
            if (_mapper != null) return _mapper;

            var config = new MapperConfiguration(cfg =>
            {
                UserMappings(cfg);
                BookMappings(cfg);
                AuthoMappings(cfg);
                UserBookStateMappings(cfg);
                UserBookMappings(cfg);
                CarBookingMappings(cfg);
            });

            _mapper = config.CreateMapper();

            return _mapper;
        }

        private static void CarBookingMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TempCarBooking, CarBooking>()
                .ForMember(db => db.User, opt => opt.Ignore())
                .ForMember(db => db.Car, opt => opt.Ignore())
                .ReverseMap();

            cfg.CreateMap<TempCar, Car>()
                .ReverseMap();
        }

        private static void UserMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TempUserType, UserType>()
                .ReverseMap();

            cfg.CreateMap<TempUser, User>()
                .ForMember(db => db.DateUserWasAdded, opt => opt.Ignore())
                .ForMember(db => db.UserType, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(db => db.UserType, opt => opt.MapFrom(d => d.UserType));
        }

        private static void BookMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TempBook, Book>()
                .ReverseMap();
        }

        private static void UserBookMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TempUserBook, UserBook>()
                .ForMember(db => db.UserBookStates, opt => opt.Ignore())
                .ForMember(db => db.User, opt => opt.Ignore())
                .ForMember(db => db.Book, opt => opt.Ignore())
                .ReverseMap()
                 .ForMember(db => db.CurrentState, opt => opt.MapFrom(src => src.UserBookStates.OrderByDescending(f => f.UserBookStatusId).FirstOrDefault()));
        }

        private static void UserBookStateMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TempUserBookState, UserBookState>()
                .ReverseMap();

            cfg.CreateMap<UserBookStatus, UserBookStatus>();
        }

        private static void AuthoMappings(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TempAuthor, Author>()

                .ReverseMap();
        }
    }
}
