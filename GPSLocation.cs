using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSRouteOptimization
{
    public class GPSLocation
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal Elevation { get; set; }

        public GPSLocation(decimal lat, decimal lon, decimal elev)
        {
            Latitude = lat;
            Longitude = lon;
            Elevation = elev;
        }
    }
}