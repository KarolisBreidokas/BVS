
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<OrderedPart> Parts { get; set; }
        [Key]
        public int Id { get; set; }
        public int AuthorId { get; set; }

    }

}