using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMapSample.Strategies
{
    public class PedestrianRoute : IRoute
    {
        public string TravelMode => "Pedestrian";

        public List<string> GetRoute(Coordinate startPoint, Coordinate finishPoint)
        {
            return new List<string> { "P1", "P2", "P3", "P4", "P5", "P6" };
        }

        public int GetTimeLengthMinutes()
        {
            return 105;
        }
    }
}
