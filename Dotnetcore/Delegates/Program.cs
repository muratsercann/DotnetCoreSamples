namespace Dotnetcore
{
    internal class Program
    {
        public delegate void Callback(string message);
        public static void PrintMessage(string str)
        {
            Console.WriteLine(str);
        }
        private static void Main(string[] args)
        {
            Callback c = new Callback(PrintMessage);
            c("naber ! ");
        }
    }
}