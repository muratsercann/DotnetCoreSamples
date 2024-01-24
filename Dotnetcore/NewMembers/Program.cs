
/// <summary>
/// If you want your derived class to have a member with 
/// the same name as a member in a base class, 
/// you can use the "new" keyword to hide the base class member. 
/// The new keyword is put before the return type of 
/// a class member that is being replaced.
/// 
/// 
/// Hidden base class members may be accessed 
/// from client code by casting the instance of 
/// the derived class to an instance of the base class. 
/// 
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Shape A = new Shape();
        A.Draw();

        //casting make hidden base class accessible
        Shape B = (Shape)(new Triangle());
        B.Draw();  // Calls the Shape.Draw.

        Triangle C = new Triangle();
        C.Draw();  // Calls the Triangle.Draw.

    }
}

public class Shape
{
    public string TypeName => this.GetType().Name;
    public void Draw()
    {
        Console.WriteLine($"Shape says -> I am drawing ({TypeName})");
        WorkField++;
    }
    public int WorkField;
    public int WorkProperty
    {
        get { return 0; }
    }
}

public class Triangle : Shape
{
    public new void Draw()
    {
        Console.WriteLine($"Triangle says -> I am drawing ({TypeName})");
        WorkField++;
    }
    public new int WorkField;
    public new int WorkProperty
    {
        get { return 0; }
    }
}