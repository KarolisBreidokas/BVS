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

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(SubscribedATM))]
        public int ATMId { get; set; }
    }

}