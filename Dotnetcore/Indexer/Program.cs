using System.Collections.Generic;
using System;

namespace Dotnetcore
{
    internal class Program
    {
        private static void Main()
        {
            Person Sam = new Person();
            Sam.Name = "Sam";
            Sam.Children.Add(new Person() { Name = "J.S1" });
            Sam.Children.Add(new Person() { Name = "J.S2" });
            Sam.Children.Add(new Person() { Name = "J.S3" });

            Console.WriteLine(Sam[1].Name);

        }
    }

    public class Person
    {
        public string? Name { get; set; }

        public List<Person>? Children { get; set; } = new List<Person>();

        public Person()
        {
            
        }

        public Person this[int index]
        {
            get
            {
                return Children[index];
            }

            set
            {
                Children[index] = value;
            }
        }

        ~Person()
        {
            Console.WriteLine("Deconstructor");
        }

    }

}