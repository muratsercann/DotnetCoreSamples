using System.Threading;
using System;
using System.Threading.Tasks;

internal class Program
{
    private static void Main()
    {
        for (int i = 1; i <= 15; i++)
        {
            MyFunction(i);
        }

    }

    private static async Task MyFunction(int num)
    {
        uint iterationCount = 10;
        if (num % 3 == 0)
        {
            await Task.Delay(500);
        }

        Console.Write("{0}, ", num);
    }
}















