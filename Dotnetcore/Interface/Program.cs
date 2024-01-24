internal class Program
{
    private static void Main(string[] args)
    {
        var shapes = new List<IShape> {
            new Triangle(),
            new Rectangle()
        };

        foreach (var item in shapes)
        {
            item.Draw();
        }

        Console.ReadLine();
    }
}

interface IShape
{
    void Draw();
}


public class Triangle : IShape
{
    public void Draw()
    {
        Console.WriteLine($"Drawing {this.GetType().Name}");
    }
}


public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine($"Drawing {this.GetType().Name}");
    }
}
