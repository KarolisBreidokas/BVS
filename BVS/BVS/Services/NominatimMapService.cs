using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Models;
using BVS.Services.Interfaces;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;
namespace BVS.Services
{
    public class NominatimMapService:IMapService
    {
        public async Task<ICollection<MapDataDto>> GetAtmLocations(ICollection<ATM> atms)
        {
            var t = new ForwardGeocoder();
            var ans = atms.AsParallel().Select(async x =>
            {
                var request = new ForwardGeocodeRequest() {queryString = x.Address};
                var response = await t.Geocode(request);
                MapLocation location = null;
                if (response.Length > 0)
                {
                    location = new MapLocation()
                    {
                        Latitude = response[0].Latitude,
                        Longitude = response[0].Longitude
                    };
                }

                return new MapDataDto
                {
                    Atm = x,
                    Location = location
                };
            });
            return await Task.WhenAll(ans);
        }
    }
}
