using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BVS.Models;
using BVS.Data.Repositories.Interfaces;

using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Controllers
{
    public class ATMController : Controller
    {
        private readonly IATM_Repository repo;
        private readonly IJobRepository repoJob;
        private readonly IMessageRepository repoMessages;
        private readonly IPartRepository repoPart;

        public ATMController(IATM_Repository repo, IJobRepository repoJob, IMessageRepository repoMessages, IPartRepository repoPart)
        {
            this.repo = repo;
            this.repoJob = repoJob;
            this.repoMessages = repoMessages;
            this.repoPart = repoPart;
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
            var atms = await repo.getATMs();
            int mes = rand.Next(1, 5);
            string message = "";
            if (mes == 1)
            {
                var listOfATMs = atms.ToList();
                int atm = rand.Next(listOfATMs.Count);
                await repo.updateATMState(listOfATMs[atm].Id, Data.Models.ATM_State.Neveikia);

                var parts = await repoPart.Select() as List<ATM_Part>;

                int partId = rand.Next(parts.Count);
                message = "Detalės gedimas " + parts[partId].Name;
                var brokenPart = new NewPartBrokenMessage()
                {
                    AtmId = listOfATMs[atm].Id,
                    Date = DateTime.Now,
                    PartId = parts[partId].Id
                };

                await repoJob.CreateJob(new NewJobDto() { Description = message, State = Data.Models.JobState.Nepriskirtas });

                await repoMessages.SaveMessage(brokenPart);

                


                //informuoti vartotojus kad bankomatas neveikia
            }
            else if (mes == 2)
            {

                var listOfATMs = atms.ToList();
                int atm = rand.Next(listOfATMs.Count);
                await repo.updateATMState(listOfATMs[atm].Id, Data.Models.ATM_State.ReikiaAptarnavimo);

                var parts = await repoPart.Select();

                List<ATM_Part> cartridge = new List<ATM_Part>();

                foreach (var p in parts)
                {
                    if (p.Name.ToLower().Contains("cartridge"))
                        cartridge.Add(p);
                }

                int cartirgeId = rand.Next(cartridge.Count);

                message = "Baiginėjasi kasetė " + cartridge[cartirgeId].Name;


                var emptyCartridge = new NewEmptyCasseteMessage()
                {
                    AtmId = listOfATMs[atm].Id,
                    Date = DateTime.Now,
                    CartridgeId = cartridge[cartirgeId].Id
                };

                await repoJob.CreateJob(new NewJobDto() { Description = message, State = Data.Models.JobState.Nepriskirtas });

                await repoMessages.SaveMessage(emptyCartridge);
                

                //informuoti vartotojus kad bankomate liko nedaug pinigu
            }
            else
            {
                var listOfATMs = atms.ToList();
                int atm = rand.Next(listOfATMs.Count);
                await repo.updateATMState(listOfATMs[atm].Id, Data.Models.ATM_State.Veikia);


                var noProblems = new NewInformationalMessageDto()
                {
                    AtmId = listOfATMs[atm].Id,
                    Date = DateTime.Now,
                    Body = "Grazi diena"
                };
                await repoMessages.SaveMessage(noProblems);
            }

            return Redirect("ViewATMs");
        }
    }
}