internal class Program
{
    private static void Main(string[] args)
    {
       
        unchecked
        {
            int a = int.MaxValue + 1;
            Console.WriteLine("a : " + a);
        }

        // //Output : a : -2147483648
        // // burda anın değeri int minumum değer olur ve hata vermeden değer taşar ve başa döner


        // checked
        // {
        //     int a = int.MaxValue;
        //     a++;
        //     Console.WriteLine("a : " + a);

        //     //Hata : Unhandled exception. 
        //     //System.OverflowException: Arithmetic operation resulted in an overflow.
        // }
    }
}