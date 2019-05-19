using System;
using BVS.Data.DTOs;
using BVS.Data.Models;
using BVS.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BVS.Services
{
    [Obsolete("Cannot be use without Api key. Use "+nameof(NominatimMapService)+"")]
    public class GoogleMapsService : IMapService
    {

        public async Task<ICollection<MapDataDto>> FindLocations(ICollection<ATM> atms)
        {
            var t = new GoogleMaps.LocationServices.GoogleLocationService();
            var ans = atms.Select(x =>
            {
                var location = t.GetLatLongFromAddress(x.Address);
                return new MapDataDto()
                {
                    Atm = x,
                    Location = new MapLocation()
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude
                    }
                };
            }).ToList();
            return ans;
        }
    }
}
