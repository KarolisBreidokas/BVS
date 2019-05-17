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
                User = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync(),
                SubscribedATM = await _context.ATMs.Where(x => x.Id == atmId).FirstOrDefaultAsync()
            };
            await _context.SaveChangesAsync();
        }

        public bool Delete(int userId, int atmId)
        {
            throw new NotImplementedException();
        }

        public Subscription Get(int userId, int atmId)
        {
            throw new NotImplementedException();
        }

        //useriu sarasas kurie yra uzsiprenumerave sita bankomata
        public ICollection<User> GetByATM(int atmId)
        {
            //REIKIA NZN KAIP PADARYT
            throw new NotImplementedException();
        }

        public ICollection<ATM> GetByUser(int userId)
        {
            //REIKIA NZN KAIP PADARYT
            throw new NotImplementedException();
        }
    }
}
