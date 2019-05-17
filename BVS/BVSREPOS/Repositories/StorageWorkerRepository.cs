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

        public void createNewStorageWorker(newStorageWorkerDto workerDto)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public StorageWorker getStorageWorker(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<StorageWorker> getStorageWorkers()
        {
            var ans = _storageWorkers.ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public ICollection<StorageWorker> search(string surname)
        {
            var ans = _storageWorkers.Where(x => x.Surname.Contains(surname)).ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public void updateStorageWorkerInfo(int id, newStorageWorkerDto workerDto)
        {
            throw new NotImplementedException();
        }
    }

}
