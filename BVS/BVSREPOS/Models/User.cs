/**
* @(#) User.cs
*/
using System.ComponentModel.DataAnnotations;
namespace BVS.Data.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }

    } 
}
