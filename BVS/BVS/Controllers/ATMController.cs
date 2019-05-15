using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BVS.Models;

namespace BVS.Controllers
{
    public class ATMController : Controller
    {
        public IActionResult ViewATMs()
        {
            return View();
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