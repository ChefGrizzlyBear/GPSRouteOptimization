using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSRouteOptimization
{
    public class Route
    {
        public List<Place> Places {get;set;}

        public string StartLocationName {get; set;}

        public string EndLocationName {get; set;}

        public double Distance {get;set;}

        public Route (List<Place> places, double distance)
        {
            Places = places;
            Distance = distance;
            StartLocationName = places[0].Name;
            EndLocationName = places[places.Count - 1].Name;
        }

        public string ConcatUniqueRouteName(){
            string returnString = "";
            foreach(Place p in Places){
                returnString += " " + p.Name;
            }

            return returnString;
        }
    }
}