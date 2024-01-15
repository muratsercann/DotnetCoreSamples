using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovarianceVsContravariance
{

    public static class Delegates
    {
        public static void Run()
        {
            //Consume(new Base());
            //Consume(new Derived());

            //Action<Base> actBase = Consume;
            //actBase(new Base());
            //actBase(new Derived());

            //Action<Derived> actDerived = Consume;
            //actDerived(new Derived());

            //actDerived = actBase;// contravariance olduğu için Base -> Derived atanabildi.

            /*Console.WriteLine("\n\nMyAction d = new MyAction(Consume);");
            MyAction d = Consume<Base>;
            d(new Base());
            d(new Derived());

            Console.WriteLine("\n\nMyGenericAction<Base> e = new MyGenericAction<Base>(Consume);");
            MyGenericAction<Base> e = new MyGenericAction<Base>(Consume<Base>);
            e(new Base());
            e(new Derived());*/

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // |||||||||||||||||||||||||||||||||||||||||
            // vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv

            MyGenericAction<Derived> consOfDerived = null;
            MyGenericAction<Base> consOfBase = Consume<Base>;
            consOfDerived = consOfBase;
            //Bu delegeyi "in" ile contravariance yapmamız
            //delegate void MyGenericAction<in T>(T b);
            //Base tipindeki delegeyi derived tipindekine atama yaparken işimize yarıyor :
        }

        delegate void MyAction(Base b);
        delegate void MyGenericAction<in T>(T b);

        public static void Consume<T>(T input)
        {
            Console.WriteLine($"{input.GetType()} is being consumed !");
        }

        public static Base Produce()
        {
            return new Base();
        }
    }

    public class Base { }

    public class Derived : Base { }
}
