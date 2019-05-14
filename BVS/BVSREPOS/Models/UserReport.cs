

using System;
/**
* @(#) UserReport.cs
*/
namespace BVS.Data.Models
{
    public class UserReport
    {
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public User Author { get; set; }

        public int Id { get; set; }

    } 
}
