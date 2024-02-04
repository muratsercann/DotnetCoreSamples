namespace Dotnetcore
{
    internal class Program
    {
        public delegate void Callback(string message);
        public delegate void GenericCallback<T>(string message);
        public delegate int SumDelegate(int a, int b);
        public static void PrintMessage(string str)
        {
            Console.WriteLine($"PrintMessage(string str) :");
            Console.WriteLine($"message : {str}");
            Console.WriteLine();
        }

        public static void PrintMessage<T>(string str)
        {
            Console.WriteLine($"PrintMessage<T>(string str) :");
            Console.WriteLine($"Generic Type : {typeof(T)}");
            Console.WriteLine($"generic message : {str}");
            Console.WriteLine();
        }

        public static int Sum(int a, int b)
        {
            return (a + b);
        }

        private static void Main(string[] args)
        {
            Callback c = new Callback(PrintMessage);
            c("hello..");

            var c2 = new GenericCallback<int>(PrintMessage<int>);
            c2("hello..");

            //Declaring Types
            SumDelegate d1 = Sum;
            SumDelegate d2 = new SumDelegate(Sum);
            SumDelegate d3 = (int a, int b) =>
            {
                return a + b;
            };

        }
    }
}