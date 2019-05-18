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
    public class StorageWorkerRepository : IStorageWorkerRepository
    {
        private readonly DbSet<StorageWorker> _storageWorkers;
        private readonly BVSDBContext _context;

        public StorageWorkerRepository(BVSDBContext context)
        {
            _context = context;
            _storageWorkers = _context.StorageWorkers;
        }

        public async Task createNewStorageWorker(newStorageWorkerDto workerDto)
        {
            var worker = workerDto.MapToStorageWorker(new StorageWorker());
            _storageWorkers.Add(worker);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> delete(int id)
        {
            var worker = await _storageWorkers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if(worker is null)
                throw new NotImplementedException();
            _storageWorkers.Remove(worker);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<StorageWorker> getStorageWorker(int id)
        {
            var worker = await _storageWorkers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (worker is null)
                throw new NotImplementedException();
            return worker;
        }

        public async Task<ICollection<StorageWorker>> getStorageWorkers()
        {
            var ans = await _storageWorkers.ToListAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public async Task<ICollection<StorageWorker>> search(string surname)
        {
            var ans = await _storageWorkers.Where(x => x.Surname.Contains(surname)).ToArrayAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public async Task updateStorageWorkerInfo(int id, newStorageWorkerDto workerDto)
        {
            var worker = await _storageWorkers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (worker is null)
                throw new NotImplementedException();
            _storageWorkers.Attach(worker);
            workerDto.MapToStorageWorker(worker);
            await _context.SaveChangesAsync();
        }
    }

}
