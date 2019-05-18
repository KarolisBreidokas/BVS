using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BVS.Models;
using BVS.Data.Repositories.Interfaces;

using BVS.Data.DTOs;
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

        public IActionResult UpdateATM(int atmId)
        {
            var atm = repo.getATM(atmId);

            return View(atm);
        }

        public ActionResult RemoveATM(int atmId)
        {
            repo.delete(atmId);
            var atms = repo.getATMs();
            return View("ViewATMs", atms);
        }

        [HttpPost]
        public ActionResult AddATM(string Address, string AdditionalInfo)
        {
            NewATMDto newATM = new NewATMDto()
            {
                Address = Address,
                AditionalInfo = AdditionalInfo
            };
            repo.createNewATM(newATM);

            var atms = repo.getATMs();
            return View("ViewATMs", atms);
        }

        [HttpPost]
        public ActionResult UpdateATM(int atmId, string Address, string AdditionalInfo)
        {
            NewATMDto update = new NewATMDto()
            {
                Address = Address,
                AditionalInfo = AdditionalInfo
            };
            repo.changeATMData(atmId, update);

            var atm = repo.getATM(atmId);
            return View(atm);
        }

        [HttpPost]
        public ActionResult ViewATMs(string Search)
        {
            var atm = repo.search(Search);
            return View(atm);
        }
    }
}