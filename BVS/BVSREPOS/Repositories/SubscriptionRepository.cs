using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Models;
using BVS.Data.Repositories.Interfaces;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace BVS.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly DbSet<Subscription> _subscriptions;
        private readonly BVSDBContext _context;

        public SubscriptionRepository(BVSDBContext context)
        {
            _context = context;
            _subscriptions = _context.Subscription;
        }

        public async Task Create(int userId, int atmId)
        {
            var subscriptionEntity = new Subscription
            {
                UserId = userId,
                ATMId = atmId
            };
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int userId, int atmId)
        {
            var sub = await _subscriptions.Where(x => x.UserId == userId && x.ATMId == atmId).FirstOrDefaultAsync();
            if (sub is null)
                throw new NullReferenceException(nameof(sub));
            _subscriptions.Remove(sub);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Subscription> Get(int userId, int atmId)
        {
            var sub = await _subscriptions.Include(x=>x.User)
                .Include(x=>x.SubscribedATM)
                .Where(x => x.UserId == userId && x.ATMId == atmId).FirstOrDefaultAsync();
            if (sub is null)
                throw new NullReferenceException(nameof(sub));
            return sub;
        }

        //useriu sarasas kurie yra uzsiprenumerave sita bankomata
        public async Task<ICollection<User>> GetByATM(int atmId)
        {
            var subs = await _subscriptions.Include(x => x.User)
                .Where(x => x.ATMId == atmId).Select(x => x.User).ToListAsync();
            if (subs is null)
                throw new NullReferenceException(nameof(subs));
            return subs;
        }

        public async Task<ICollection<ATM>> GetByUser(int userId)
        {
            var subs = await _subscriptions.Include(x => x.User)
                .Where(x => x.UserId == userId).Select(x => x.SubscribedATM).ToListAsync();
            if (subs is null)
                throw new NullReferenceException(nameof(subs));
            return subs;
        }
    }
}
