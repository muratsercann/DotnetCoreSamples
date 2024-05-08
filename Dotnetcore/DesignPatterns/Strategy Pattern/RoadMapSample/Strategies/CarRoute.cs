using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMapSample.Strategies
{
    public class CarRoute : IRoute
    {
        public string TravelMode => "Car";

        public List<string> GetRoute(Coordinate startPoint, Coordinate finishPoint)
        {
            return new List<string> { "C1", "C2", "C3", "C4" };
        }

        public int GetTimeLengthMinutes()
        {
            return 10;
        }
    }
}
