using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
internal class Program
{
    class Person
    {
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }

        public string? Address { get; set; }

        public List<Person> Children { get; set; } = new();
        public bool IsValid { get; set; }
        public Person()
        {
            Name = string.Empty;//Because, it is non-nullable;

        }
    }
    private static void Main(string[] args)
    {
        Person p = new Person();
        //int len = p.Address?.Length; //compiler error
        int? length = p.Address?.Length;//if Addres is null, then null is assigned to length variable;

       // var t = p.Address.Length;

        p.Address = null;//no warning.Because, it is nullable type.x

        bool isValid2 = p?.Children[0]?.IsValid ?? false;

        if (p?.Children[0]?.IsValid ?? false)
        {

        }
        PrintMessageUpper("Hi Murat :)");
        Console.ReadLine();
    }

    static void PrintMessageUpper(string? message)
    {
        if (!IsNull(message))
        {
            var upperFormat = message.ToUpper();//No warning because of NotNullWhen Attribute in IsNull method
            Console.WriteLine($"{DateTime.Now}: {message.ToUpper()}");
        }
    }

    static bool IsNull([NotNullWhen(false)] string? s) => s == null;
}


