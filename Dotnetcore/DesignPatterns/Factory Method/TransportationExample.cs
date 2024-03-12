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

            ITransportation truck =  TransportationService.CreateTransportation(
                new TruckTransportationFactory());

            ITransportation ship = TransportationService.CreateTransportation(
                new ShipTransformationFactory()
                );

            
            truck.Deliver(cargo);
            ship.Deliver(cargo);

            //or 

            TransportationService.Deliver(truck, cargo);
            TransportationService.Deliver(ship, cargo);
        }
    }

    //Bu patterndeki interfacelerin generic bir kullanıma
    //uygun olduğunu göstermek ve
    //Transportation işlemlerinin farklı bir servis üzerinden yapılabildiğini
    //simüle etmek için yazıldı.
    //Pattern içerisinde kullanımı şart değil.
    public static class TransportationService
    {
        public static void Deliver(ITransportation transportation, Cargo cargo)
        {
            transportation.Deliver(cargo);
        }

        public static ITransportation CreateTransportation(ITransportationFactory factory)
        {
            return factory.Create();
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

    public interface ITransportation
    {
        void Deliver(Cargo cargo);
    }

    public interface ITransportationFactory
    {
        ITransportation Create(); 
    }

    public class ShipTransportation : ITransportation
    {
        public void Deliver(Cargo cargo) { }
    }

    public class TruckTransportation : ITransportation
    {
        public void Deliver(Cargo cargo) { }
    }

    public class TruckTransportationFactory : ITransportationFactory
    {
        public ITransportation Create()
        {
            return new TruckTransportation();
        }
    }

    public class ShipTransformationFactory : ITransportationFactory
    {
        public ITransportation Create() {
            return new ShipTransportation();
        }
    }

}
