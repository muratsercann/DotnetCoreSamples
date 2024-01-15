using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using System.Collections;

namespace myProgram
{
    internal class Program
    {

        private static void Main(string[] args)
        {

            IEnumerable<object> strings = new List<string>();
            
            ICovariance<object> str = new MyCovariance<string>();

            IContravariance<string> obj2 = new MyContravariance<object>();
        }
    }

    public interface ICovariance<out T>
    {
        void Write();
    }

    public class MyCovariance<T> : ICovariance<T>
    {
        public void Write()
        {
            Console.WriteLine(typeof(T).ToString());
        }
    }


    public interface IContravariance<in T>
    {
        void Write();
    }

    public class MyContravariance<T> : IContravariance<T>
    {
        public void Write()
        {
            Console.WriteLine(typeof(T).ToString());
        }
    }
}



public interface IRepository<T> where T : class
{
    bool Add(T model);
    bool Add<A>(A model) where A : class;
}

public class Repository<Type> : IRepository<Type> where Type : class
{
    // protected ArabaContext _arabaContext;
    public Repository()
    {
        // _arabaContext = arabaContext;
    }

    public bool Add(Type model)
    {
        return Add<Type>(model);
    }

    public bool Add<A>(A model) where A : class
    {
        //Table<A>().Add(model);
        //Save();
        return true;
    }

    public void Run()
    {

    }
}


public class ArabaController : Repository<Araba>
{
    public bool Ekle(Araba araba)
    {
        Run();
        return Add(araba);
    }
}


public class Araba
{

}