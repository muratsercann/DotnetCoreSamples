internal class Program
{
    private static void Main(string[] args)
    {
        var shapes = new List<Shape> { new Triangle(), new Rectangle() };

        foreach (var item in shapes)
        {
            item.Draw();
        }

        Console.ReadLine();
    }
}

public abstract class Shape
{
    public abstract void Draw();
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