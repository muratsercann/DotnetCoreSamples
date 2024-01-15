
internal class Program
{
    delegate void MyAction(Base b);
    delegate void MyGenericAction<in T>(T b);

    private static void Main(string[] args)
    {
        #region !! Important

        CovarianceVsContravariance.Delegates.Run();

        IEnumerable<Derived> aaa = new List<Derived>();
        IEnumerable<Base> bbb = aaa;

        Action<Base> ccc = (target) => { Console.WriteLine(target.GetType().Name); };
        Action<Derived> ddd = ccc;
        ddd(new Derived());

        #endregion

        #region Basics
        Base x = new Base();
        Base y = new Derived();
        Derived z = new Derived();
        //z = new Base();//compile error

        IProducer<Base> prodOfBase = new Producer<Base>();
        Base a = prodOfBase.Create();
        //Derived b = prodOfBase.Create();// compile error

        IProducer<Derived> prodOfDerived = new Producer<Derived>();
        Derived b = prodOfDerived.Create();
        Base c = prodOfDerived.Create();

        IConsumer<Base> consOfBase = new Consumer<Base>();
        consOfBase.Consume(new Base());
        consOfBase.Consume(new Derived());

        IConsumer<Derived> consOfDerived = new Consumer<Derived>();
        consOfDerived.Consume(new Derived());
        //consOfDerived.Consume(new Base()); //Compile Error

        ///////////////////////////////////////////////////////////////////

        IProducer<Base> p = prodOfBase;         // IProducer<Base>
        IProducer<Base> q = prodOfDerived;      // IProducer<Derived>
        IProducer<Derived> r = prodOfDerived;   // IProducer<Derived>
        //IProducer<Derived> r = prodOfBase;    // IProducer<Base> Error!!!!

        IConsumer<Derived> t = consOfDerived;   //IConsumer<Derived>
        //beacuse we write IConsumer<in target> , - IConsumer<Derived> u = consOfBase; - works

        IConsumer<Derived> u = consOfBase;  // ÖNEMLİ !!!

        Console.WriteLine("\n\nIConsumer<Derived> u = consOfBase;");
        Console.Write($"u.Consume(new Base()); : Error: ");
        //u.Consume(new Base()); // ! Error !
        Console.Write($"consOfBase.Consume(new Derived()); : ");
        u.Consume(new Derived());

        IConsumer<Base> v = consOfBase;         //IConsumer<Base>
                                                //IConsumer<Base> w = consOfDerived;    //IConsumer<Derived>   

        #endregion
    }
}

class Producer<T> : IProducer<T>
{
    public T Create()
    {
        return default(T);
    }
}

class Consumer<T> : IConsumer<T>
{
    public void Consume(T input)
    {
        Console.WriteLine(typeof(T));
    }
}

public interface IProducer<out T>
{
    T Create();
}

public interface IConsumer<in T>
{
    void Consume(T input);
}

public class Base { }

public class Derived : Base { }