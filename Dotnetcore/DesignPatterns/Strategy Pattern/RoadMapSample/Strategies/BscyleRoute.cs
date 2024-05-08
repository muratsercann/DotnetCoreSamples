using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMapSample.Strategies
{

    public class BscyleRoute : IRoute
    {
        public string TravelMode => "Bscyle";

        public List<string> GetRoute(Coordinate startPoint, Coordinate finishPoint)
        {
            return new List<string> { "B1", "B2", "B3", "B4", "B5" };
        }

        public int GetTimeLengthMinutes()
        {
            return 40;
        }
    }
}
