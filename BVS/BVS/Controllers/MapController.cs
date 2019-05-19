using BVS.Data.DTOs;
using BVS.Data.Repositories.Interfaces;
using BVS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BVS.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapService _mapService;
        private readonly IATM_Repository _atmRepository;

        public MapController(IMapService mapService, IATM_Repository atmRepository)
        {
            _mapService = mapService;
            _atmRepository = atmRepository;
        }

        public async Task<IActionResult> Index()
        {
            var atms = await _atmRepository.getATMs();
            var data = await _mapService.GetAtmLocations(atms);
            var minLat = double.MaxValue;
            var maxLat = double.MinValue;
            var minLong = double.MaxValue;
            var maxLong = double.MinValue;
            foreach (var mapData in data)
            {
                if (mapData.Location is null) continue;
                minLat = Math.Min(minLat, mapData.Location.Latitude);
                maxLat = Math.Max(maxLat, mapData.Location.Latitude);
                minLong = Math.Min(minLong, mapData.Location.Longitude);
                maxLong = Math.Max(maxLong, mapData.Location.Longitude);
            }

            var ret = new MapViewDto()
            {
                Data = data,
                InitialZoom = 10,
                CenterPoint = new MapLocation()
                {
                    Longitude = (maxLong + minLong) / 2,
                    Latitude = (maxLat + maxLat) / 2
                }
            };
            return View(ret);
        }
    }
}