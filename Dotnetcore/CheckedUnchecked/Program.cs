
internal class Program
{
    private static void Main(string[] args)
    {

        int a = int.MaxValue; // 2147483647
        a++;// the value of a overflows and becomes -2147483648.
        Console.WriteLine($"value of a : {a}");
        //COMPILE TIME ERROR.
        //int b = int.MaxValue + 1;


        //this throws an exeption in RUNTIME.
        checked
        {
            try
            {
                int c = int.MaxValue; // 2147483647
                c++;//Throws OverflowException because of 'checked'

            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"c++ -> {ex.Message}");
            }
        }

        unchecked
        {
            int d = int.MaxValue + 1;
            Console.WriteLine($"value of d : {d}");

            //d overflows and its value becomes -2147483648. No Error if its value overflows.
        }
    }
}