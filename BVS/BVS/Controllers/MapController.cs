using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data;
using BVS.Data.Repositories.Interfaces;
using BVS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BVS.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapService _mapService;
        private readonly IATM_Repository _atmRepository;

        public MapController( IMapService mapService, IATM_Repository atmRepository)
        {
            _mapService = mapService;
            _atmRepository = atmRepository;
        }

        public async Task<IActionResult> Index()
        {
            var atms =await _atmRepository.getATMs();
            var data =await _mapService.GetAtmLocations(atms);
            return View(data);
        }
    }
}