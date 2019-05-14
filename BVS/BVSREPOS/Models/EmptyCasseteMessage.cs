/**
 * @(#) EmptyCasseteMessage.cs
 */

namespace BVS.Data.Models
{
    public class EmptyCasseteMessage : AttentionNeededMessage
    {
        public Cartridge Cartridge { get; set; }

    }

}