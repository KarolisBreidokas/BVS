using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class WarehouseController : Controller
    {
        public IActionResult PartsList()
        {
            return View();
        }

        public IActionResult OrdersPage()
        {
            return View();
        }

        public IActionResult OrderForm()
        {
            return View();
        }
    }
}