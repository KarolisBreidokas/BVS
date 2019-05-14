/**
 * @(#) PartBrokenMessage.cs
 */
namespace BVS.Data.Models
{

    public class PartBrokenMessage : AttentionNeededMessage
    {
        public ATM_Part Part { get; set; }

    }

}