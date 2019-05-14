/**
 * @(#) PartInStorage.cs
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Data.Models
{

    public class PartInStorage
    {
        public int Count { get; set; }

        public ATM_Part parts { get; set; }

        public Rack racks { get; set; }

        [ForeignKey(nameof(racks))]
        public int RackId { get; set; }

        [ForeignKey(nameof(parts))]
        public int PartId { get; set; }
    }

}