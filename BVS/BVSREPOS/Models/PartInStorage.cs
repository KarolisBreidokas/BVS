/**
 * @(#) PartInStorage.cs
 */
namespace BVS.Data.Models
{

    public class PartInStorage
    {
        public int Count { get; set; }

        public ATM_Part parts { get; set; }

        public Rack racks { get; set; }

    }

}