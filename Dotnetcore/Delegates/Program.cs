namespace Dotnetcore
{
    internal class Program
    {
        public delegate void Callback(string message);
        public delegate void GenericCallback<T>(string message);
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


        private static void Main(string[] args)
        {
            Callback c = new Callback(PrintMessage);
            c("hello..");

            var c2 = new GenericCallback<int>(PrintMessage<int>);
            c2("hello..");

        }
    }
}