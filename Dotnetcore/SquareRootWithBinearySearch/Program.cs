public class Program
{
    public static void Main()
    {
        var result = SquareRoot(89.0f);
        Console.WriteLine("\nresult : " + result);
        //Console.WriteLine($"float : {(float)(9.433981 * 9.433981) == 89.0f} "); //true
        //Console.WriteLine($"double : {(double)(9.433981 * 9.433981) == 89.0d} "); //false
        //Console.WriteLine($"decimal : {(decimal)(9.433981 * 9.433981) == 89.0m} "); //false
    }

    public static float SquareRoot(float num)
    {

        int count = 1;
        float low = 0.0f;
        float high = num;
        
        Console.WriteLine($"{"no",-15} {"low",-15} {"high",-15} {"mid",-15} {"high-low",-11}");
        Console.WriteLine($"{"------",-15} {"------",-15} {"------",-15} {"------",-15} {"------",-11}");
        
        while (high - low > 0.000000001 && count < 1000)
        {

            float mid = low + (high - low) / 2;
            if (mid * mid == num)
            {
                return mid;
            }


            if (mid * mid > num)
                high = mid;
            else
                low = mid;
            Console.WriteLine($"{count + ".",-15} {low,-15} {high,-15} {mid,-15} {(float)(high - low),-11}");
            count++;
        }

        return -1;
    }
}