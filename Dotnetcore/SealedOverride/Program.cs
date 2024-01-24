internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("(Base)(<Derived1>).DoWork output :");
        Base b = new Derived1();//casting to the base
        b.DoWork();

        Console.WriteLine("\n<Derived2>.DoWork output :");
        Derived2 s2 = new Derived2();
        s2.DoWork();

        Console.WriteLine("\n<Derived3>.DoWork output :");
        Derived3 s3 = new Derived3();
        s3.DoWork();//calls the method in Derived2

        //Burda sub2 içerisindeki DoWork çalışır
        //Çünkü Derived3'ün DoWork'u override eden kendine en yakın atası Derived2'dir.
        Console.WriteLine("\n(Base)(<Derived3>).DoWork output :");
        Base s4 = new Derived3();
        s4.DoWork();
    }
}

public class Base
{
    public virtual void DoWork()
    {
        Console.WriteLine($"DoWork in class Base");
    }
}
public class Derived1 : Base
{
    public override void DoWork()
    {
        Console.WriteLine($"DoWork in class Derived1");
    }
}

public class Derived2 : Derived1
{
    /// <summary>
    /// because of the "sealed" keyword, 
    /// Derived class from Derived2 cannot override DoWork virtual method. 
    /// </summary>
    public sealed override void DoWork()
    {
        Console.WriteLine($"DoWork in class Derived2");
    }

}

public class Derived3 : Derived2
{
    //Compiler Error !!!
    //public override void DoWork()
    //{
    //    Console.WriteLine($"DoWork in class Derived3");
    //}

    //No error with "new" keyword
    public new void DoWork()
    {
        Console.WriteLine($"DoWork in class Derived3 with 'new' keyword");
    }
}
