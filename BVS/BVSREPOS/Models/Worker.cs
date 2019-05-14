/**
 * @(#) Worker.cs
 */
namespace BVS.Data.Models
{

    public class Worker : User
    {
        public string PhoneNo { get; set; }

        public Job assigned { get; set; }

    }

}