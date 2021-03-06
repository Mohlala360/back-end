﻿using System;

namespace ControllerApp.Domains.Users
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellPhonenumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }
        public DateTime DateUserWasAdded { get; set; }
    }
}
