using System;
using System.Collections.Generic;
using System.Text;
using BVS.Data.Models;

namespace BVS.Data.DTOs
{
    public class MapDataDto
    {
        public MapLocation Location { get; set; }
        public ATM Atm { get; set; }
    }

    public class MapLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
