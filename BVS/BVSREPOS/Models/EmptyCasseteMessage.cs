/**
 * @(#) EmptyCasseteMessage.cs
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Data.Models
{
    [Table("EmptyCasseteMessages")]
    public class EmptyCasseteMessage : AttentionNeededMessage
    {
        public Cartridge Cartridge { get; set; }

        [ForeignKey(nameof(Cartridge))]
        [Column("PartId")]
        public int CartridgeId { get; set; }
    }

}