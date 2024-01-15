
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
        //      int b = int.MaxValue + 1;    //compile time error : 
        //
        //      Error CS0220  The operation overflows at compile time in 
        //      checked mode CheckedUnchecked    D:\Projects 2023\Dotnetcore\Dotnetcore\CheckedUnchecked\Program.cs  8   Active
        //
        //      int a = int.MaxValue;         
        //      a++;
        //      Console.WriteLine("a : " + a);
        //     
        //      //Runtime Error :
        //      //Error : Unhandled exception. 
        //      //System.OverflowException: Arithmetic operation resulted in an overflow.
        // }
    }
}