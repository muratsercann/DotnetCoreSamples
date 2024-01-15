..using System;

class GenericClass<T1, T2>
{
    private T1 _t1;
    private T2 _t2;
    public GenericClass(T1 t1, T2 t2)
    {
        _t1 = t1;
        _t2 = t2;
    }

    public void Write()
    {
        Console.WriteLine("type of T1 : {0}", typeof(T1));
        Console.WriteLine("type of T2 : {0}", typeof(T2));

        Console.WriteLine("value of t1 : {0}", _t1);
        Console.WriteLine("value of t2 : {0}", _t2);
    }

}

static class GenericClass
{
    public static GenericClass<T1, T2> Create<T1, T2>(T1 value1, T2 value2)
    {
        return new GenericClass<T1, T2>(value1, value2);
    }
}


internal class Program
{

    private static void Main(string[] args)
    {
        // int a = 5;
        // string b = "Hi Muro !";

        // myGenericMethod(a);

        // var a = new GenericClass<int, string>(3, "Nerdesin ?");
        // a.Write();

        var b = GenericClass.Create("Seleam", 4568);
        b.Write();

        // myGenericMethod("sadsa", 2.3f);


    }


    static void myGenericMethod<T>(T obj)
    {
        Console.WriteLine(obj.GetType());
    }

    static void myGenericMethod<T1, T2>(T1 t1, T2 t2)
    {
        Console.WriteLine("type of t1 : {0}", t1.GetType());
        Console.WriteLine("type of t2 : {0}", t2.GetType());
    }

}


