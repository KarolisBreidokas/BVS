using System;
using System.ComponentModel.DataAnnotations;

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
    }
}
