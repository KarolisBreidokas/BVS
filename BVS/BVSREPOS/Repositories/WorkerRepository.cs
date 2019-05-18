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
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DbSet<Worker> _workers;
        private readonly BVSDBContext _context;

        public WorkerRepository(BVSDBContext context)
        {
            _context = context;
            _workers = _context.Workers;
        }

        public async Task<int> createNewEmployee(NewWorkerDto workerDto)
        {

            var userEntity = workerDto.MapToWorker(new Worker());
            _workers.Add(userEntity);
            await _context.SaveChangesAsync();
            return userEntity.Id;
        }

        public async Task<bool> delete(int id)
        {
            var worker = await _workers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (worker is null)
                throw new NotImplementedException();
            _workers.Remove(worker);
            return await _context.SaveChangesAsync() > 0;
        }

        public  async Task<Worker> getEmployee(int id)
        {
            var worker = await _workers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (worker is null)
                throw new NotImplementedException();
            return worker;
        }

        public async Task< ICollection<Worker>> getEmployees()
        {
            var ans =await _workers.ToListAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public async Task<ICollection<Worker>> search(string surname)
        {
            var ans = await _workers.Where(x => x.Surname.Contains(surname)).ToListAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public async Task updateAccountInfo(int id, NewWorkerDto workerDto)
        {
            var user = await getEmployee(id);
            _workers.Attach(user);
            workerDto.MapToWorker(user);
            await _context.SaveChangesAsync();
        }
    }

}
