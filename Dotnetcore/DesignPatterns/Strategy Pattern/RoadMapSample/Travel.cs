using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMapSample
{
    public class Travel
    {
        private readonly Coordinate _startPoint;
        private readonly Coordinate _finishPoint;

        IRoute routeStrategy { get; set; }


        public Travel(Coordinate startPoint, Coordinate finishPoint)
        {
            _startPoint = startPoint;
            _finishPoint = finishPoint;
        }

        public void SetStrategy(IRoute route)
        {
            routeStrategy = route;
        }

        public void WriteTravelInfo()
        {
            var route = GetRoute();
            var time = GetTimeLength();

            Console.WriteLine($"Travel Mode     : {routeStrategy.TravelMode} ");
            Console.Write($"Start Point     : ");
            _startPoint.PrintCoordinate();
            Console.Write($"Finish Point    : ");
            _finishPoint.PrintCoordinate();
            Console.WriteLine($"Time Length     : {time} min");
            Console.Write("Route           : ");
            foreach (var item in route)
            {
                Console.Write($"{item} - ");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public List<string> GetRoute()
        {
            return routeStrategy.GetRoute(_startPoint, _finishPoint);
        }

        public int GetTimeLength()
        {
            return routeStrategy.GetTimeLengthMinutes();
        }

    }
}
