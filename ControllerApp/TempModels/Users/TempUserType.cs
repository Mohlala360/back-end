
using AutoMapper;
using ControllerApp.Domains.Users;

namespace ControllerApp.TempModels.Users
{
    [AutoMap(typeof(UserType))]
    public class TempUserType
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }
    }
}
