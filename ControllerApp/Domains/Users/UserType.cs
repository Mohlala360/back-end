
namespace ControllerApp.Domains.Users
{
    public enum UserTypes
    {
			User = 1,
			Librarian,
            System,
    }
    public class UserType
    {
        public int UserTypeId { get; set; }
        public string Name { get; set; }
    }
}
