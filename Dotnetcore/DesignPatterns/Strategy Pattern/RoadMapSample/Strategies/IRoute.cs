using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMapSample.Strategies
{
    public interface IRoute
    {
        int GetTimeLengthMinutes();

        List<string> GetRoute(Coordinate startPoint, Coordinate finishPoint);

        string TravelMode { get; }
    }
}
