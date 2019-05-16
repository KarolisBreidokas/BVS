using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class SubscriptionController : Controller
    {
        public IActionResult SubscriptionView()
        {
            return View();
        }
    }
}