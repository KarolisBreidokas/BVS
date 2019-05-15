using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult ViewEmployees()
        {
            return View();
        }
    }
}