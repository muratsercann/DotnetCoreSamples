
namespace Dotnetcore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Person p1 = new Person() { Name = "p1" };
            Person p2 = new Person() { Name = "p2" };

            Person p3 = p1 * p2;

            Console.WriteLine(p3.Name);
        }
    }

    public class Person
    {
        public string? Name { get; set; }

        public List<Person>? Children { get; set; } = new List<Person>();

        public Person()
        {

        }

        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
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

        public static Person Procreate(Person p1, Person p2)
        {
            return new Person() { Name = "Child of " + p1.Name + " and " + p2.Name };
        }

    }
}