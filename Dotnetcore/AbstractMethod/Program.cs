using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        var shapes = new List<Shape> { new Triangle(), new Rectangle() };

        foreach (var item in shapes)
        {
            item.Draw();
        }

        foreach (var item in shapes)
        {
            string message = item.SayHello();
            Console.WriteLine($"{message}");
        }

        Console.ReadLine();
    }
}

public abstract class Shape 
{
    public abstract void Draw();

    public string SayHello()
    {
        return $"SayHello() in Shape type says : Hi ! My type is {this.GetType().Name}";
    }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine($"Draw {this.GetType().Name}");
    }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine($"Draw {this.GetType().Name}");
    }
}