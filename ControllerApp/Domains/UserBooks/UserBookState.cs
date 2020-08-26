using System;

namespace ControllerApp.Domains.UserBooks
{
    public class UserBookState
    {
        public int UserBookStateId { get; set; }
        public int UserBookId { get; set; }
        public virtual UserBook UserBook { get; set; }
        public int UserBookStatusId { get; set; }
        public virtual UserBookStatus UserBookStatus { get; set; }
        public DateTime UserBookStateDateUpdated { get; set; }
    }
}
