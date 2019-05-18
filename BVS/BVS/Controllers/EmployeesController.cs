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

        public IActionResult ViewEmployees()
        {
            AllEmployees employees = new AllEmployees(repoWorker.getEmployees(), repoStorageWorker.getStorageWorkers());
            return View(employees);
        }
    }
}