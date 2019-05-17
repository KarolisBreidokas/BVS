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
    public class OrderRepository:IOrderRepository
    {
        private readonly DbSet<Order> _orders;
        private readonly BVSDBContext _context;

        public OrderRepository(BVSDBContext context)
        {
            _context = context;
            _orders = _context.Orders;
        }

        public async Task<int> AddOrder(NewOrderDto orderDto)
        {
            Random gen = new Random();
            DateTime start = DateTime.Now;
            start.AddDays(gen.Next(7, 30));

            var orderEntity = new Order
            {
                Date = DateTime.Now,
                ArivalDate = start,
                Author = await _context.StorageWorkers.Where(x => x.Id == orderDto.AuthorId).FirstOrDefaultAsync(),
                //DAR TRUKSTA NZN KAIP PADARYT
            };

            await _context.SaveChangesAsync();
            return orderEntity.Id;
        }

        public ICollection<Order> Select()
        {
            var ans = _orders.ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }
    }
}
