/**
* @(#) ATM_Part.cs
*/

using System.ComponentModel.DataAnnotations;

namespace BVS.Data.Models
{

    public class ATM_Part
    {
        public string Name { get; set; }

        public string Description { get; set; }
        [Key]
        public int Id { get; set; }

    } 
}
