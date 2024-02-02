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
        //Burada sealed kullandığımız için. Artık D sınıfını miras alan sınıf bu metodu override edemez.
        //Aynı metoddan oluşturmak isterse "new" anahtar kelimesini kullanabilir 
        public sealed override void DoWork()
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

        //new ile oluşturduğumuz bu metod kalıtıma dahil edilmez
        public new void DoWork()
        {
            Console.WriteLine("Do work for class E ('new' keyword)");
        }
    }

}