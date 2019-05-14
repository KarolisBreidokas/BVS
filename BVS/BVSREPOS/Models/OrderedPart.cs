/**
 * @(#) OrderedPart.cs
 */
namespace BVS.Data.Models
{

    public class OrderedPart
    {
        public float Price { get; set; }

        public ATM_Part Part { get; set; }

        public Order order { get; set; }

    }

}