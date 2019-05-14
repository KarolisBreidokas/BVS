
using System ;
/**
* @(#) Order.cs
*/
namespace BVS.Data.Models
{

    public class Order
    {
        public DateTime Date { get; set; }

        public DateTime ArivalDate { get; set; }

        public StorageWorker Author { get; set; }

        public OrderedPart Parts { get; set; }

        public int Id { get; set; }

    }

}