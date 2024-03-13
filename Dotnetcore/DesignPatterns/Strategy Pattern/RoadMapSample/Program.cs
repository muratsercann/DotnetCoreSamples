using RoadMapSample;

internal class Program
{
    private static void Main(string[] args)
    {
        var startPoint = new Coordinate(38,14,22.2,'N', 28,41,46.6,'E');
        var finishPoint = new Coordinate(38,36,41.1,'N', 27,25,32.3,'E');
        
        Travel travel = new Travel(startPoint, finishPoint);

        travel.SetStrategy(new PedestrianRoute());
        travel.WriteTravelInfo();

        travel.SetStrategy(new BscyleRoute());
        travel.WriteTravelInfo();

        travel.SetStrategy(new CarRoute());
        travel.WriteTravelInfo();

        Console.WriteLine();
    }
}








