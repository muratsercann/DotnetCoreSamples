using System.Threading;
using System;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main()
    {
        for (int i = 1; i <= 15; i++)
        {
            await MyFunction(i);
        }

        Console.ReadLine();

    }

    private static async Task MyFunction(int num)
    {
        if (num % 3 == 0)
        {
            await Task.Delay(500);
        }

        Console.Write("{0}, ", num);
    }
}















