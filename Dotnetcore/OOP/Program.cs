using System;
using System.Security.AccessControl;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Rectangle r = new Rectangle(4, 5);
// Console.WriteLine(r.calcArea());

Shape s = new Rectangle(3, 5);
Console.WriteLine("My area is " + s.calcArea());
Console.WriteLine(">> : " + s.name());

public abstract class Shape
{
    public decimal widthBase;
    public abstract decimal calcArea();
    public Shape()
    {
        Console.WriteLine("Constructor of Shape : ");
    }

    public virtual string name()
    {
        return "My type is shape";
    }

}

public class A
{
    public virtual string GetName()
    {
        return "Name is A";
    }
}

public class Rectangle : Shape
{
    decimal width = 0;
    decimal height = 0;

    public Rectangle(decimal w, decimal h)
    {
        width = w;
        height = h;
    }

    public override decimal calcArea()
    {
        return width * height;
    }

    // public override string name()
    // {
    //     return "My type is rectangle";
    // }

}
