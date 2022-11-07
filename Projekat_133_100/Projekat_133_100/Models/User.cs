using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat_133_100.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ReservedTable { get; set; }

        public User() { }

        public User(string Username, string Email, string Password, string ConfirmPassword)
        {
            this.Username = Username;
            this.Email = Email;
            this.Password = Password;   
            this.ConfirmPassword = ConfirmPassword;
        }
    }
}
