/**
 * @(#) PartBrokenMessage.cs
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Data.Models
{

    [Table("PartBroken")]
    public class PartBrokenMessage : AttentionNeededMessage
    {
        public ATM_Part Part { get; set; }

        [ForeignKey(nameof(Part))]
        [Column("PartId")]
        public int PartId { get; set; }
    }

}