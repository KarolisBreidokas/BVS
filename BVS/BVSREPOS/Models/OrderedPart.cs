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
        public int PartId { get; set; }
        public int OrderId { get; set; }
    }

}