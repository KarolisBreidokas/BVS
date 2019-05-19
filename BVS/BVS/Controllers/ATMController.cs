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
        private readonly IJobRepository repoJob;

        public ATMController(IATM_Repository repo, IJobRepository repoJob)
        {
            this.repo = repo;
            this.repoJob = repoJob;
        }

        public async Task<IActionResult> ViewATMs()
        {
            var atms = await repo.getATMs();
            return View(atms);
        }

        public IActionResult AddATM()
        {
            return View();
        }

        public async Task<IActionResult> UpdateATM(int atmId)
        {
            var atm = await repo.getATM(atmId);

            return View(atm);
        }

        public async Task<ActionResult> RemoveATM(int atmId)
        {
            await repo.delete(atmId);
            return Redirect("ViewATMs");
        }

        [HttpPost]
        public async Task<ActionResult> AddATM(string Address, string AdditionalInfo)
        {
            NewATMDto newATM = new NewATMDto()
            {
                Address = Address,
                AditionalInfo = AdditionalInfo
            };
            await repo.createNewATM(newATM);

            var atms = await repo.getATMs();
            return View("ViewATMs", atms);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateATM(int atmId, string Address, string AdditionalInfo)
        {
            NewATMDto update = new NewATMDto()
            {
                Address = Address,
                AditionalInfo = AdditionalInfo
            };
            await repo.changeATMData(atmId, update);

            var atm = await repo.getATM(atmId);
            return View(atm);
        }

        [HttpPost]
        public async Task<ActionResult> ViewATMs(string Search)
        {
            if (Search != null)
            {
                var atm = await repo.search(Search);
                return View(atm);
            }
            else
            {
                var atm = await repo.getATMs();
                return View(atm);
            }
            
        }




        public async Task<ActionResult> MessageATM()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var atms = await repo.getATMs();
            int mes = rand.Next(1, 4);
            string message = "";
            if (mes == 1)
            {
                message = "Detalės gedimas " + new string(Enumerable.Repeat(chars, 10).Select(s => s[rand.Next(s.Length)]).ToArray());
                var listOfATMs = atms.ToList();
                int atm = rand.Next(listOfATMs.Count);
                await repo.updateATMState(listOfATMs[atm].Id, Data.Models.ATM_State.Neveikia);

                //issaugo zinute i db

                await repoJob.CreateJob(new NewJobDto() { Description = message, State = Data.Models.JobState.Nepriskirtas });


                //informuoti vartotojus kad bankomatas neveikia
            }
            else if (mes == 2)
            {
                message = "Baiginėjasi kasetė " + new string(Enumerable.Repeat(chars, 10).Select(s => s[rand.Next(s.Length)]).ToArray());
                var listOfATMs = atms.ToList();
                int atm = rand.Next(listOfATMs.Count);
                await repo.updateATMState(listOfATMs[atm].Id, Data.Models.ATM_State.ReikiaAptarnavimo);

                //issaugo zinute i db

                await repoJob.CreateJob(new NewJobDto() { Description = message, State = Data.Models.JobState.Nepriskirtas });

                //informuoti vartotojus kad bankomate liko nedaug pinigu
            }
            else
            {
                var listOfATMs = atms.ToList();
                int atm = rand.Next(listOfATMs.Count);
                await repo.updateATMState(listOfATMs[atm].Id, Data.Models.ATM_State.Veikia);
            }


            return Redirect("ViewATMs");
        }
    }
}