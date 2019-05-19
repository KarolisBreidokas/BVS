using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BVS.Data.Repositories.Interfaces;

using BVS.Data.DTOs;

namespace BVS.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly IPartRepository partRepo;
        private readonly IOrderRepository orderRepo;
        private readonly NewOrderDto newOrderDTO;

        private ICollection<OrderedPartDto> orderedParts;

        public WarehouseController(IPartRepository partRepo)
        {
            this.partRepo = partRepo;
        }

        public IActionResult PartsList()
        {
            return View();
        }

        public async Task<IActionResult> OrdersPage()
        {
            var orders = await orderRepo.Select();
            return View(orders);
        }


        public IActionResult OrderForm()
        {
            var parts = partRepo.Select();
            return View(parts);
        }

        [HttpPost]
        public async Task<ActionResult> OrderForm(List<string> listbox)
        {
            int id = 0;
            List<int> ids = new List<int>();
            foreach (var item in listbox)
            {
                id = 0;
                foreach (var part in await partRepo.Select())
                {
                    if (part.Name == item)
                    {
                        id = part.Id;
                        break;
                    }
                }
                ids.Add(id);
            }

            foreach (var _id in ids)
            {
                OrderedPartDto newOrder = new OrderedPartDto()
                {
                    PartId = _id,
                    Price = 30
                };
                newOrderDTO.PartList.Add(newOrder);
            }

            //newOrderDTO.AuthorId = session.Id;
            newOrderDTO.Date = DateTime.Now;
            await orderRepo.AddOrder(newOrderDTO);

            var orders = await orderRepo.Select();

            return View("OrdersPage", orders);
        }
    }
}