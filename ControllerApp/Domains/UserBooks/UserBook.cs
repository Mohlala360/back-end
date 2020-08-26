using ControllerApp.Domains.Books;
using ControllerApp.Domains.Users;
using System.Collections.Generic;

namespace ControllerApp.Domains.UserBooks
{
    public class UserBook
    {
        public int UserBookId { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<UserBookState> UserBookStates { get; set; }
    }
}
