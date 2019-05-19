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
        

        public WarehouseController(IOrderRepository orderRepo, IPartRepository partRepo)
        {
            this.orderRepo = orderRepo;
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


        public async Task<IActionResult> OrderForm()
        {
            var parts = await partRepo.Select();
            return View(parts);
        }

        [HttpPost]
        public async Task<ActionResult> OrderForm(List<string> listbox)
        {
            NewOrderDto newOrderDTO = new NewOrderDto();
            ICollection<OrderedPartDto> list = new List<OrderedPartDto>();
            int id = 0;
            List<int> ids = new List<int>();
            var parts = await partRepo.Select();
            foreach (var item in listbox)
            {
                id = 0;
                foreach (var part in parts)
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
                list.Add(newOrder);              
            }
            newOrderDTO.PartList = list;
            newOrderDTO.AuthorId = -2;
            newOrderDTO.Date = DateTime.Now;
            await orderRepo.AddOrder(newOrderDTO);

            var orders = await orderRepo.Select();

            return View("OrdersPage", orders);
        }
    }
}