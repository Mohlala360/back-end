using System.Collections.Generic;
using System.Linq;
using ControllerApp.Domains.Users;
using ControllerApp.Interfaces;

namespace ControllerApp.Services
{
    public class UserService : IUserInterface
    {

        protected DatabaseContext _databaseContext { get; set; }

        public UserService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public User AddUser(User user)
        {
            var u = new User
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
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

        public void UpdateUser(User user, User updates)
        {
            user.Email = updates.Email;
            user.Name = updates.Name;
            user.Surname = updates.Surname;
            _databaseContext.SaveChanges();
        }
    }
}
