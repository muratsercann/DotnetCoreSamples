using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadMapSample
{
    public record Coordinate
    {
        public double LatitudeDegree { get; set; } 
        public double LatitudeMinute { get; set; } 
        public double LatitudeSecond { get; set; } 
        public char LatitudeDirection { get; set; }

        public double LongitudeDegree { get; set; }
        public double LongitudeMinute { get; set; }
        public double LongitudeSecond { get; set; }
        public char LongitudeDirection { get; set; }

        public Coordinate()
        {
                
        }
        public Coordinate(double latDegree, double latMinute, double latSecond, char latDirection,
                          double lonDegree, double lonMinute, double lonSecond, char lonDirection)

        {
            SetCoordinate(latDegree, latMinute, latSecond, latDirection, LongitudeDegree, LongitudeMinute, lonSecond, lonDirection);
        }
        public void SetCoordinate(double latDegree, double latMinute, double latSecond, char latDirection,
                                  double lonDegree, double lonMinute, double lonSecond, char lonDirection)
        {
            LatitudeDegree = latDegree;
            LatitudeMinute = latMinute;
            LatitudeSecond = latSecond;
            LatitudeDirection = latDirection;

            LongitudeDegree = lonDegree;
            LongitudeMinute = lonMinute;
            LongitudeSecond = lonSecond;
            LongitudeDirection = lonDirection;
        }

        public void PrintCoordinate()
        {
            Console.Write($"{LatitudeDegree}°{LatitudeMinute}'{LatitudeSecond}\"{LatitudeDirection}");
            Console.WriteLine($", {LongitudeDegree}°{LongitudeMinute}'{LongitudeSecond}\"{LongitudeDirection}");
        }
    }
}
