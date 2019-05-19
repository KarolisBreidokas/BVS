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
    public class SubscriptionController : Controller
    {

        private readonly ISubscriptionRepository repo;

        public SubscriptionController(ISubscriptionRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> SubscriptionView()
        {
            var subs = await repo.GetByUser(HttpContext.Session.GetComplex<User>("User").Id);
            return View(subs);
        }

        public async Task<IActionResult> Subscribe(int id)
        {
            var user = HttpContext.Session.GetComplex<User>("User");
            if (user is null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account");
            }

            await repo.Create(user.Id, id);
            return RedirectToAction("Index", "Map");
            throw new NotImplementedException();
        }

    }
}