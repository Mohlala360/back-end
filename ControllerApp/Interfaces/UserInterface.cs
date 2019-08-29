using ControllerApp.Domains.Users;
using System.Collections.Generic;

namespace ControllerApp.Interfaces
{
    public interface IUserInterface
    {
        User AddUser(User user);
        void UpdateUser(User user, User updates);
        void DeleteUser(User user);
        User GetUser(int id);
        List<User> GetUsers();
    }
}
