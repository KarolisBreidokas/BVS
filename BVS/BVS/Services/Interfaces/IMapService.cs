using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BVS.Data.DTOs;
using BVS.Data.Models;

namespace BVS.Services.Interfaces
{
    public interface IMapService
    {
        Task<ICollection<MapDataDto>> FindLocations(ICollection<ATM> atms);
    }
}
