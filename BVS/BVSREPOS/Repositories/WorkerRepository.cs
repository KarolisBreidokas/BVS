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
    public class WorekerRepository : IWorkerRepository
    {
        private readonly DbSet<Worker> _workers;
        private readonly BVSDBContext _context;

        public WorekerRepository(BVSDBContext context)
        {
            _context = context;
            _workers = _context.Workers;
        }

        public int createNewEmployee(NewWorkerDto workerDto)
        {
            throw new NotImplementedException();
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public Worker getEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Worker> getEmployees()
        {
            var ans = _workers.ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public ICollection<Worker> search(string surname)
        {
            var ans = _workers.Where(x => x.Surname.Contains(surname)).ToList();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public void updateAccountInfo(int id, NewWorkerDto workerDto)
        {
            throw new NotImplementedException();
        }
    }

}
