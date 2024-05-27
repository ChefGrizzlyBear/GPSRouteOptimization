using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSRouteOptimization
{
    public class GPSLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Elevation { get; set; }

        public GPSLocation(double lat, double lon, double elev)
        {
            Latitude = lat;
            Longitude = lon;
            Elevation = elev;
        }
    }
}