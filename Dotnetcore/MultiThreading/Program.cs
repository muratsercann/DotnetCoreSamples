using MultiThreading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Numerics;

internal class Program
{
    private static readonly int loop = 30000000;
    private static async Task Main(string[] args)
    {
        await FactorialTest.CalculateFactorials(400, 40);
        await FactorialTest.CalculateFactorials(400, 80);
        await FactorialTest.CalculateFactorials(400, 100);
        await FactorialTest.CalculateFactorials(400, 200);
        await FactorialTest.CalculateFactorials(400, 400);

        //await Test_SingleThread();
        //await Test_MultiThread();

        Console.ReadLine();
    }

    private static void Test_Concurrent()
    {
        ConcurrentBag<BigInteger> concurrentBag = new ConcurrentBag<BigInteger>();

        Parallel.Invoke(
           () => FactorialTest.RunConcurently(concurrentBag, 1, 3),
           () => FactorialTest.RunConcurently(concurrentBag, 4, 6),
           () => FactorialTest.RunConcurently(concurrentBag, 7, 10)
        );

        foreach (var item in concurrentBag)
        {
            Console.WriteLine(item);
        }
    }

    private static async Task Test_SingleThread()
    {
        Stopwatch w = new Stopwatch();
        w.Start();
        Console.WriteLine($"Single Thread has started. Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        List<Task> firstTaskList = new List<Task>
        {
            System.Threading.Tasks.Task.Run(() => MyMethod(1, loop )),
        };

        await System.Threading.Tasks.Task.WhenAll(firstTaskList);
        w.Stop();
        Console.WriteLine($"\nSingle Thread finished in {w.Elapsed.TotalMilliseconds} ms");
    }

    private static async Task Test_MultiThread()
    {
        Stopwatch w = new Stopwatch();
        w.Start();
        Console.WriteLine($"Multi Thread has started. Thread ID : {Thread.CurrentThread.ManagedThreadId}");
        List<Task> secondTaskList = new List<Task>
        {
            Task.Run(() => MyMethod(1, loop,0)),
            Task.Run(() => MyMethod(1, loop,1)),
        };
        await System.Threading.Tasks.Task.WhenAll(secondTaskList);
        w.Stop();
        Console.WriteLine($"\nMulti Thread finished in {w.Elapsed.TotalMilliseconds} ms");
    }

    private static void MyMethod(int a, int b)
    {
        Console.WriteLine($"MyMethod(a,b) is running on Thread ID : {Thread.CurrentThread.ManagedThreadId}");

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
    private static void MyMethod(int a, int b, int c)
    {
        Console.WriteLine($"MyMethod(a,b,c) is running on Thread ID : {Thread.CurrentThread.ManagedThreadId}");

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