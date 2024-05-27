using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPSRouteOptimization
{
    public static class Extensions
    {
        public static List<Place> Swap(List<Place> list, int indexA, int indexB)
        {
            var tmpList = new List<Place>(list);
            Place tmp = tmpList[indexA];
            tmpList[indexA] = tmpList[indexB];
            tmpList[indexB] = tmp;
            return tmpList;
        }
    }
}