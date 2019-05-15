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


        public IActionResult ViewATMs()
        {
            var atms = repo.getATMs();
            return View(atms);
        }

        public IActionResult AddATM()
        {
            ATMadd ATM = new ATMadd("", "", 0);
            return View(ATM);
        }

        public IActionResult UpdateATM()
        {
            ATMadd ATM = new ATMadd("Adresas is db", "Papildoma info is db", 0);
            return View(ATM);
        }

        public IActionResult RemoveATM()
        {
            return View("ViewATMs");
        }

        [HttpPost]
        public ActionResult AddATM(string Address, string AdditionalInfo)
        {
            if (Address == null && AdditionalInfo == null)
            {
                ATMadd ATM = new ATMadd(null, null, 1);
                return View(ATM);
            }
            else if (Address == null)
            {
                ATMadd ATM = new ATMadd(null, AdditionalInfo, 2);
                return View(ATM);
            }
            else if (AdditionalInfo == null)
            {
                ATMadd ATM = new ATMadd(Address, null, 3);
                return View(ATM);
            }
            else
            {
                return View("ViewATMs");

            }
        }

        [HttpPost]
        public ActionResult UpdateATM(string Address, string AdditionalInfo)
        {
            if (Address == null && AdditionalInfo == null)
            {
                ATMadd ATM = new ATMadd(null, null, 1);
                return View(ATM);
            }
            else if (Address == null)
            {
                ATMadd ATM = new ATMadd(null, AdditionalInfo, 2);
                return View(ATM);
            }
            else if (AdditionalInfo == null)
            {
                ATMadd ATM = new ATMadd(Address, null, 3);
                return View(ATM);
            }
            else
            {
                ATMadd ATM = new ATMadd("Adresas is db", "Papildoma info is db", 0);
                return View(ATM);

            }
        }
    }
}