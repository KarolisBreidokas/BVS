using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BVS.Models;
using BVS.Data.Repositories.Interfaces;

namespace BVS.Controllers
{
    public class ATMController : Controller
    {
        private readonly IATM_Repository repo;

        public ATMController(IATM_Repository repo)
        {
            this.repo = repo;
        }
        /*
         public ATMController()
         {
            this.repo = new StubAtmRepository();\\StubAtmRepository - menama repositorija, kuri grąžina menamas reikšmes
         }
         */

        public IActionResult ViewATMs()
        {
            var atms = repo.getATMs();
            return View(atms);
        }

        public IActionResult AddATM()
        {
            return View();
        }

        public IActionResult UpdateATM()
        {
            return View();
        }

        public ActionResult RemoveATM()
        {
            return View("ViewATMs");
        }

        [HttpPost]
        public ActionResult AddATM(string Address, string AdditionalInfo)
        {
            return View("ViewATMs");
        }

        [HttpPost]
        public ActionResult UpdateATM(string Address, string AdditionalInfo)
        {
            return View();
        }
    }
}