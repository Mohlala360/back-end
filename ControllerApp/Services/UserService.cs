using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ControllerApp.Domains.Users;
using ControllerApp.Interfaces;
using ControllerApp.TempModels.Users;

namespace ControllerApp.Services
{
    public class UserService : IUserInterface
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public UserService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public User AddUser(TempUser tempUser)
        {
            var u = new User
            {
                Name = tempUser.Name,
                Surname = tempUser.Surname,
                Email = tempUser.Email,
                CellPhonenumber = tempUser.CellPhonenumber,
                DateOfBirth = tempUser.DateOfBirth,
                UserTypeId = tempUser.UserTypeId
            };

            u.DateUserWasAdded = DateTime.Now;
            _databaseContext.Users.Add(u);
            _databaseContext.SaveChanges();
            return u;
        }

        public void DeleteUser(User user)
        {
            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _databaseContext.Users.FirstOrDefault(u => u.UserId == id);
        }

        public List<User> GetUsers()
        {
            return _databaseContext.Users.OrderByDescending(u => u.UserId).ToList();
        }

        public void UpdateUser(User user, TempUser tempUser)
        {
            user.Name = tempUser.Name;
            user.Surname = tempUser.Surname;
            user.Email = tempUser.Email;
            user.CellPhonenumber = tempUser.CellPhonenumber;
            user.DateOfBirth = tempUser.DateOfBirth;
            user.UserTypeId = tempUser.UserTypeId;

            _databaseContext.SaveChanges();
        }

        public List<UserType> GetUserTypes()
        {
            return _databaseContext.UserTypes.ToList();
        }

        public UserType GetUserType(int id)
        {
            return _databaseContext.UserTypes.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _databaseContext.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}
