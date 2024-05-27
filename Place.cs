using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSRouteOptimization
{
    public class Place
    {
        public GPSLocation GPSLocation { get; set; }
        public string Name { get; set; }

        public Place(string name, double lat, double lon, double elev)
        {
            Name = name;
            GPSLocation = new GPSLocation(lat, lon, elev);
        }
    }
}

