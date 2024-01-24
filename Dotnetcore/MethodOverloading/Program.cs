

/// <summary>
/// Method Overloading is known as compile-time (or static) polymorphism
/// because each of the different overloaded methods is resolved 
/// when the application is compiled. It has several 
/// names like “Compile Time Polymorphism” or “Static Polymorphism” 
/// and sometimes it is called “Early Binding”.
/// 
/// Compiler automatically calls required method to check number of parameters 
/// and their type which are passed into that method.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {

        Calculator calculator = new Calculator();

        int result1 = calculator.Sum(5, 10);          // 15
        double result2 = calculator.Sum(3.5, 2.7);    // 6.2
        string result3 = calculator.Sum("Hello, ", "World!");  // "Hello, World!"
        
    }
}

public class Calculator
{
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Sum(int a, int b, int c = 0)
    {
        return a + b + c;
    }


    public double Sum(double a, double b)
    {
        return a + b;
    }

    public string Sum(string a, string b)
    {
        return a + b;
    }

    public int Sum(double a, int b)
    {
        return (int)(a + b);
    }

    public int Sum(int a, double b)
    {
        return (int)(a + b);
    }
}

