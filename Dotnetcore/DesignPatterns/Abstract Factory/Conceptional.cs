using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Conceptional
    {
        static void Example()
        {
            IProductFactory factory1 = new Type1_Factory();
            IProductFactory factory2 = new Type2_Factory();

            IProductA a1 = factory1.CreateProductA();
            IProductA a2 = factory2.CreateProductA();

            IProductB b1 = factory1.CreateProductB();
            IProductB b2 = factory2.CreateProductB();

            IProductC c1 = factory1.CreateProductC();
            IProductC c2 = factory2.CreateProductC();
        }
    }

    interface IProductA { }
    interface IProductB { }
    interface IProductC { }

    class ProductA_Type1 : IProductA { }
    class ProductA_Type2 : IProductA { }

    class ProductB_Type1 : IProductB { }
    class ProductB_Type2 : IProductB { }

    class ProductC_Type1 : IProductC { }
    class ProductC_Type2 : IProductC { }

    interface IProductFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
        IProductC CreateProductC();
    }

    class Type1_Factory : IProductFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA_Type1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB_Type1();
        }

        public IProductC CreateProductC()
        {
            return new ProductC_Type1();
        }
    }

    class Type2_Factory : IProductFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA_Type2();
        }
        public IProductB CreateProductB()
        {
            return new ProductB_Type2();
        }

        public IProductC CreateProductC()
        {
            return new ProductC_Type2();
        }
    }


}
