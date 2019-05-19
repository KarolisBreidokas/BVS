using BVS.Data.DTOs;
using BVS.Data.Models;
using BVS.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BVS.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly DbSet<Job> _jobs;
        private readonly BVSDBContext _context;

        public JobRepository(BVSDBContext context)
        {
            _context = context;
            _jobs = _context.Jobs;
        }

        public async Task AssignWorker(int workerId, ICollection<int> jobIds)
        {
            var worker = await _context.Workers.Where(x => x.Id == workerId).FirstOrDefaultAsync();

            foreach (int id in jobIds)
            {
                var ans = await _jobs.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (ans is null)
                    throw new NotImplementedException();

                ans.State = JobState.Atliekamas;
                ans.AssignedWorker = worker;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateJob(NewJobDto message)
        {
            var jobEntity = new Job
            {
                Description = message.Description,
                State = message.State
            };
            _jobs.Add(jobEntity);
            await _context.SaveChangesAsync();
            return jobEntity.Id;
        }

        private IQueryable<Job> IncldueDependencies(DbSet<Job> jobs)
        {
            return jobs.Include(x => x.AssignedWorker)
                .Include(x => x.Reason)
                .ThenInclude(x => x.Autor);
        }

        public async Task<ICollection<Job>> SelectJobs()
        {
            var ans = await IncldueDependencies(_jobs).ToListAsync();
            if (ans is null)
                throw new NotImplementedException();
            return ans;
        }

        public async Task UpdateStatus(int JobId, JobState state)
        {
            var ans = await _jobs.Where(x => x.Id == JobId).FirstOrDefaultAsync();
            if (ans is null)
                throw new NotImplementedException();
            _jobs.Attach(ans);

            ans.State = state;

            await _context.SaveChangesAsync();
        }
    }
}
