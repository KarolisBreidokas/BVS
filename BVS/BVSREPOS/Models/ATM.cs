/**
* @(#) ATM.cs
*/
namespace BVS.Data.Models
{

    public class ATM
    {
        public string Address { get; set; }

        public string AditionalInfo { get; set; }

        ATM_Transport Transportations { get; set; }

        public ATM_State State { get; set; }

        public bool Online { get; set; }

        public int Id { get; set; }

    }

}