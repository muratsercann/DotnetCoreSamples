/// <summary>
/// 
/// It has several names like “Run Time Polymorphism” 
/// or “Dynamic Polymorphism” and sometime it is called
/// “Late Binding”. It is called runtime (or dynamic) polymorphism 
/// because the type of the calling object is not 
/// known until runtime, and therefore the method implementation 
/// that runs is determined at runtime.
/// 
/// Fields can't be virtual;
/// only 
///    -Methods, 
///    -Properties, 
///    -Events, and 
///    -Indexers can be virtual.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape> {
            new Shape(),
            new Circle(),
            new Square(),
        };

        foreach (var item in shapes)
        {
            item.Draw();
        }

        /*
            Console Output:
            
            Drawing a shape(Shape)
            Drawing a circle(Circle)
            Drawing a square(Square)
        */

        Console.ReadLine();
    }
}

public class Shape
{
    /// virtual property
    public virtual string Type => this.GetType().Name;

    public virtual void Draw()
    {
        Console.WriteLine($"Drawing a shape ({Type})");
    }
}

public class Circle : Shape
{
    public override string Type => this.GetType().Name;

    public override void Draw()
    {
        Console.WriteLine($"Drawing a circle ({Type})");
        //base.Draw();
    }
}

public class Square : Shape
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing a square ({Type})");
    }
}

