using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    public static class Program2
    {
        public static void Main2()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "IPhone 14S", Code = "F4X7YZ8"},
                new Product { Name = "Dell Inspiron", Code = "A9GJ7HA" }
            };
            Cargo cargo = new Cargo();
            cargo.Address = "34 Street 45633 Berlin";
            cargo.products.AddRange(products);

            ITransportation truck = new TruckTransportationFactory().Create();
            ITransportation ship = new ShipTransformationFactory().Create();

            truck.Deliver(cargo);
            ship.Deliver(cargo);
        }
    }

    public class Product
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    public class Cargo {
        public DateTime Date { get; set; }
        public string Address { get; set; }

        public List<Product> products = new List<Product>();

    }

    interface ITransportation
    {
        void Deliver(Cargo cargo);
    }

    interface ITransportationFactory
    {
        ITransportation Create(); 
    }

    class ShipTransportation : ITransportation
    {
        public void Deliver(Cargo cargo) { }
    }

    class TruckTransportation : ITransportation
    {
        public void Deliver(Cargo cargo) { }
    }

    class TruckTransportationFactory : ITransportationFactory
    {
        public ITransportation Create()
        {
            return new TruckTransportation();
        }
    }

    class ShipTransformationFactory : ITransportationFactory
    {
        public ITransportation Create() {
            return new ShipTransportation();
        }
    }

}
