/**
 * @(#) OrderedPart.cs
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Data.Models
{

    public class OrderedPart
    {
        public float Price { get; set; }

        public ATM_Part Part { get; set; }

        public Order Order { get; set; }
        [ForeignKey(nameof(Part))]
        public int PartId { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
    }

}