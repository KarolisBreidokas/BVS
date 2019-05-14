
using System ;
using System.ComponentModel.DataAnnotations.Schema;

/**
* @(#) ATM_Transport.cs
*/
namespace BVS.Data.Models
{

    public class ATM_Transport
    {
        public ATM Transported { get; set; }

        public string NewAddress { get; set; }

        public DateTime OrderDate { get; set; }

        public int Id { get; set; }
        [ForeignKey(nameof(Transported))]
        public int AtmId { get; set; }

    } 
}
