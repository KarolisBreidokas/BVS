using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class SubscriptionController : Controller
    {

        private readonly ISubscriptionRepository repo;

        public SubscriptionController(ISubscriptionRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> SubscriptionView()
        {
            var subs = await repo.GetByUser(1002/*user ID*/);
            return View(subs);
        }
    }
}