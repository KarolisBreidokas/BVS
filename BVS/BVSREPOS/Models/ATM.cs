/**
* @(#) ATM.cs
*/

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BVS.Data.Models
{

    public class ATM
    {
        public string Address { get; set; }

        public string AditionalInfo { get; set; }

        public ICollection<ATM_Transport> Transportations { get; set; }

        public ATM_State State { get; set; }

        public bool Online { get; set; }
        [Key]
        public int Id { get; set; }

    }

}