using System;
using System.ComponentModel.DataAnnotations;
using BVS.Data.Models;
using DevOne.Security.Cryptography.BCrypt;

namespace BVS.Data.DTOs
{
    public class NewUserDto
    {
        public string Name;
        public string Surname;
        public string Username;
        public string Password;
        [EmailAddress]
        public string Email;

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
