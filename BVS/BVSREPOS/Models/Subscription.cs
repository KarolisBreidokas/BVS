/**
 * @(#) Subscription.cs
 */

namespace BVS.Data.Models
{
    public class Subscription
    {
        public User User { get; set; }

        public ATM SubscribedATM { get; set; }

    }

}