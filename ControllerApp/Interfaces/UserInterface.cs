using ControllerApp.Domains.Users;
using ControllerApp.TempModels.Users;
using System.Collections.Generic;

namespace ControllerApp.Interfaces
{
    public interface IUserInterface
    {
        User AddUser(TempUser tempUser);
        void UpdateUser(User user, TempUser tempUser);
        void DeleteUser(User user);
        User GetUser(int id);
        List<User> GetUsers();
        List<UserType> GetUserTypes();
    }
}
