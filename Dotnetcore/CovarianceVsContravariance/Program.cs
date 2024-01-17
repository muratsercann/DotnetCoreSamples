
internal class Program
{
    delegate void ContravariantDelegate<in T>(T b);

    private static void Main(string[] args)
    {
        //1. Instances of the Base and Derived classes
        Base x = new Base();
        Base y = new Derived();
        Derived z = new Derived();

        //2. Covariant Interface : IProducer<out T>
        IProducer<Base> prodOfBase = new Producer<Base>();
        IProducer<Base> prodOfBase2 = new Producer<Derived>();
        IProducer<Derived> prodOfDerived = new Producer<Derived>();

        //3. Contravariant Interface : IConsumer<in T>
        IConsumer<Base> consOfBase = new Consumer<Base>();
        IConsumer<Derived> consOfDerived = new Consumer<Derived>();

        //4.Covariant vs Contravariant
        IProducer<Base> p = prodOfBase;         // IProducer<Base>
        IProducer<Base> q = prodOfDerived;      // IProducer<Derived>
        IProducer<Derived> r = prodOfDerived;   // IProducer<Derived>

        IConsumer<Derived> t = consOfDerived;   //IConsumer<Derived>
        IConsumer<Derived> u = consOfBase;      // ÖNEMLİ !!!

        //5.Covariant IEnumerable and Action<in T>
        IEnumerable<Derived> a = new List<Derived>();
        IEnumerable<Base> b = a;

        Action<Base> actionBase = null;
        Action<Derived> actionDerived = actionBase;

        //6. Contravariant Delegate
        ContravariantDelegate<Derived> cDerived = ContravariantMethod<Base>;//delegate contravariant değilken de çalışır.
        ContravariantDelegate<Base> cBase = ContravariantMethod<Base>;
        cDerived = cBase;//delegate contravariant değilse hata verir.
    }

    public static void ContravariantMethod<T>(T input)
    {
        Console.WriteLine($"{input.GetType()} is being consumed !");
    }
}

public class Base { }

public class Derived : Base { }

//Covaraiance
public interface IProducer<out T>
{
    T Create();
}

//Contravariance
public interface IConsumer<in T>
{
    void Consume(T input);
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

