using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class ProblemController : Controller
    {
        private readonly IUserReportRepository repoReport;
        private readonly IJobRepository repoJob;
        private readonly IATM_Repository repoATM;

        public ProblemController(IUserReportRepository repoReport, IJobRepository repoJob, IATM_Repository repoATM)
        {
            this.repoReport = repoReport;
            this.repoJob = repoJob;
            this.repoATM = repoATM;
        }


        public async Task<IActionResult> ProblemForm()
        {
            var atm = await repoATM.getATMs();
            return View(atm);
        }

        [HttpPost]
        public async Task<IActionResult> ProblemForm(int ATMId, string Problem)
        {

            NewUserReportDto report = new NewUserReportDto()
            { 
                Date = DateTime.Now,
                Description = Problem,
                AuthorId = 4            //idet userio id
            };
            await repoReport.Add(report);
            await repoJob.CreateJob(new NewJobDto() { Description = Problem });

            return Redirect("~/Home/Index");
        }
    }
}