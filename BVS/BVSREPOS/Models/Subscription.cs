/**
 * @(#) Subscription.cs
 */

using System.ComponentModel.DataAnnotations.Schema;

namespace BVS.Data.Models
{
    public class Subscription
    {
        public User User { get; set; }

        public ATM SubscribedATM { get; set; }

        public int UserId { get; set; }
        public int ATMId { get; set; }
    }

}