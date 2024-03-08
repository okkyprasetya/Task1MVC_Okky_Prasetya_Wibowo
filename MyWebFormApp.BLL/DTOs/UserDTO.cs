using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebFormApp.BLL.DTOs
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string LastLogin { get; set; }
        public Boolean IsLocked { get; set; }
        public int MaxAttempt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telp { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
    }
}
