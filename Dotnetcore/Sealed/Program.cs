using System.Collections.Generic;
using System;

namespace Dotnetcore
{
    internal class Program
    {
        private static void Main()
        {
            E d = new E();
            d.DoWork();
        }
    }

    public sealed class A //sealed ile korunan A türü başka bir sınıf tarafından miras alınamaz.
    {

    }

    // public class B : A
    // {

    // }

    public class C
    {
        public virtual void DoWork()
        {
            Console.WriteLine("Do work for class C");
        }
    }
    public class D : C
    {
        public sealed override void DoWork()//Burada sealed kullandığımız için. Artık D sınıfını miras alan sınıf bu metodu override edemez.
        {
            Console.WriteLine("Do work for class D");
        }
    }

    public class E : D
    {
        // public override void DoWork()
        // {
        //     Console.WriteLine("Do work for class E");
        // }
    }

}