using ControllerApp.TempModels.Books;
using ControllerApp.TempModels.Users;
using System;
using System.Collections.Generic;

namespace ControllerApp.TempModels.UserBooks
{    
    public class TempUserBook
    {
        public int UserBookId { get; set; }
        public int BookId { get; set; }
        public TempBook Book { get; set; }
        public int UserId { get; set; }
        public TempUser User { get; set; }
        public List<TempUserBookState> UserBookStates { get; set; }
        public TempUserBookState CurrentState { get; set; }
    }
}
