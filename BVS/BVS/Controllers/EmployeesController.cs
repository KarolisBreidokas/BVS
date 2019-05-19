using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BVS.Data.Repositories.Interfaces;
using BVS.Models;

namespace BVS.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IWorkerRepository repoWorker;
        private readonly IStorageWorkerRepository repoStorageWorker;

        public EmployeesController(IWorkerRepository repoWorker, IStorageWorkerRepository repoStorageWorker)
        {
            this.repoWorker = repoWorker;
            this.repoStorageWorker = repoStorageWorker;
        }

        public async Task<IActionResult> ViewEmployees()
        {
            var workers = await repoWorker.getEmployees();
            var storageWorkers = await repoStorageWorker.getStorageWorkers();
            AllEmployees employees = new AllEmployees(workers, storageWorkers);
            return View(employees);
        }

        [HttpPost]
        public async Task<IActionResult> ViewEmployees(string Search)
        {
            if (Search != null)
            {
                var workers = await repoWorker.search(Search);
                var storageWorkers = await repoStorageWorker.search(Search);
                AllEmployees employees = new AllEmployees(workers, storageWorkers);
                return View(employees);
            }
            else
            {
                var workers = await repoWorker.getEmployees();
                var storageWorkers = await repoStorageWorker.getStorageWorkers();
                AllEmployees employees = new AllEmployees(workers, storageWorkers);
                return View(employees);
            }
           
        }
    }
}