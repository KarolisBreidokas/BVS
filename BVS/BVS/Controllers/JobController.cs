using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Configuration;
using BVS.Data.Models;
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
            await repo.AssignWorker(HttpContext.Session.GetComplex<User>("User").Id, selectedJobsId);
            var jobs = await repo.SelectJobs();
            return View("JobList",jobs);        //Viewas kaip suprantu kaskur kitur numeta rodo kelia turbut
        }
    }
}