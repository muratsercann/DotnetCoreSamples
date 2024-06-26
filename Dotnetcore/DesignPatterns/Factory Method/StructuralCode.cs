﻿using System;

namespace FactoryMethod.Structural
{
    public class StructuralCode
    {
        public static void Main()
        {
            TransportationExample.TransportationExample_Program.TransportationExample_Main();

            Factory[] factories = new Factory[2];

            factories[0] = new Factory_A();
            factories[1] = new Factory_B();


            foreach (var factory in factories)
            {
                Product product = factory.Create();

                Console.WriteLine("product type: " + product.GetType().ToString());

            }

        }
    }

    public abstract class Product
    {

    }

    public abstract class Factory
    {
        public abstract Product Create();
    }

    public class Product_A : Product
    {

    }

    public class Product_B : Product
    {

    }

    public class Factory_A : Factory
    {
        public override Product Create()
        {
            return new Product_A();
        }
    }

    public class Factory_B : Factory
    {
        public override Product Create()
        {
            return new Product_B();
        }
    }
}