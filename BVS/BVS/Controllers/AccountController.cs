using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Configuration;
using BVS.Data.DTOs;
using BVS.Data.Models;
using BVS.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;

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
        public async Task<IActionResult> Login(LoginDto details)
        {
            //determen witch screen to display
            var uid = await _repository.checkData(details);
            if (uid.HasValue)
            {
                var user = await _repository.getUserInfo(uid.Value);
                HttpContext.Session.SetComplex("User", user);
                if (user is Administrator)
                {
                    return RedirectToAction("AdministratorHomePage");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Error = @"<div>Wrong Username or Password<\div>";
            return View();
        }
    }
}