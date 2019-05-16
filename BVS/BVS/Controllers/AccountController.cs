using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _repository;

        public AccountController(IUserRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AdministratorHomePage()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string Username, string Password)
        {
            //determen witch screen to display

            return Redirect("/Account/AdministratorHomePage");
        }
    }
}