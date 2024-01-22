using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;

internal class Program
{
    private static readonly int loop = 30000000;
    private static async Task Main(string[] args)
    {

        await Test_SingleThread();
        await Test_MultiThread();        


        Console.ReadLine();
    }

    private static async Task Test_SingleThread()
    {
        Stopwatch w = new Stopwatch();
        w.Start();
        Console.Write("Single Thread ");
        List<Task> firstTaskList = new List<Task>
        {
            System.Threading.Tasks.Task.Run(() => Task(1, loop )),
        };

        await System.Threading.Tasks.Task.WhenAll(firstTaskList);
        w.Stop();
        Console.WriteLine($"in {w.Elapsed.TotalMilliseconds} ms");
    }

    private static async Task Test_MultiThread()
    {
        Stopwatch w = new Stopwatch();
        w.Start();
        Console.Write("Multi Thread ");
        List<Task> secondTaskList = new List<Task>
        {
            System.Threading.Tasks.Task.Run(() => Task(1, loop,0)),
            System.Threading.Tasks.Task.Run(() => Task(1, loop,1)),
        };
        await System.Threading.Tasks.Task.WhenAll(secondTaskList);
        w.Stop();
        Console.WriteLine($"in {w.Elapsed.TotalMilliseconds} ms");
    }

    private static void Task(int a, int b)
    {
        List<BigInteger> list = new List<BigInteger>();

        for (int i = a; i <= b; i++)
        {
            if (i % 2 >= 0)
            {
                list.Add(a * a);

            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 >= 0)
            {
                list[0] += 1546;
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 >= 0)
            {
                list[0] += 1546;
            }
        }

    }
    private static void Task(int a, int b, int c)
    {
        List<BigInteger> list = new List<BigInteger>();

        for (int i = a; i <= b; i++)
        {
            if (i % 2 == c)
                list.Add(a * a);
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 == c)
                list[0] += 1546;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (i % 2 == c)
            {
                list[0] += 1546;
            }
        }
    }

}