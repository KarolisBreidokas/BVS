using System;
using System.Collections.Generic;
using System.Text;

namespace BVS.Data.DTOs
{
    public class MapViewDto
    {
        public MapLocation CenterPoint { get; set; }
        public double InitialZoom { get; set; }
        public ICollection<MapDataDto> Data { get; set; }
    }
}
