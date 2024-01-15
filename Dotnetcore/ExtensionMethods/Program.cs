using System;
using MyExtensions;
internal class Program
{
    private static void Main(string[] args)
    {
        string value = "12345";
        bool result = value.IsNumeric();//Extensions.cs sınıfında
        Console.WriteLine(result);  // Outputs: True

        List<int> numbers = new List<int> { 1, 2, 3 };
        numbers.AddRange(4, 5, 6);

        foreach (var item in numbers)
        {
            Console.Write("{0},", item);
        }
        
    }
}

