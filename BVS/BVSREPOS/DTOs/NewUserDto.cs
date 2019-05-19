using System;
using System.ComponentModel.DataAnnotations;
using BVS.Data.Models;
using DevOne.Security.Cryptography.BCrypt;

namespace BVS.Data.DTOs
{
    public class NewUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public User MapToUser(User user)
        {
            user.Name = Name;
            user.Surname = Surname;
            user.Username = Username;
            user.Password = BCryptHelper.HashPassword(Password, BCryptHelper.GenerateSalt());
            user.Email = Email;
            return user;
        }

    }
}
