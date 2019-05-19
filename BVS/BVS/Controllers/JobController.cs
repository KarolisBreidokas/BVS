using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository repo;

        public JobController(IJobRepository repo)
        {
            this.repo = repo;
        }


        public async Task<IActionResult> JobList()
        {
            var jobs = await repo.SelectJobs();
            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> JobList(ICollection<int> selectedJobsId)
        {
            await repo.AssignWorker(1/*worker ID*/, selectedJobsId);
            return View();        //Viewas kaip suprantu kaskur kitur numeta rodo kelia turbut
        }
    }
}