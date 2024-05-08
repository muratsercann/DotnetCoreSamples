
//See Also :
//https://learn.microsoft.com/en-us/previous-versions/msp-n-p/ff650316(v=pandp.10)?redirectedfrom=MSDN
namespace Singleton;
public class Program
{
    public static async Task Main(string[] args)
    {
        await Test(Test_Singleton);
        await Test(Test_Singleton_Lock);
        await Test(Test_Singleton_StaticInitialization);
        await Test(Test_Singleton_Volatile);
        await Test(Test_Singleton_Lazy);

        Console.ReadKey();
    }

    static async Task Test(Action action)
    {
        Console.WriteLine(action.Method.Name);

        List<Task> tasks = new List<Task>();

        for (int i = 0; i < 50; i++)
        {
            tasks.Add(Task.Run(() => action()));
        }

        await Task.WhenAll(tasks);

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine();
    }

    static void Test_Singleton()
    {
        Task.Delay(500);
        Singleton_WithoutLock instance = Singleton_WithoutLock.Instance;
    }

    static void Test_Singleton_StaticInitialization()
    {
        Task.Delay(500);
        Singleton_StaticInitialization instance = Singleton_StaticInitialization.Instance;
    }

    static void Test_Singleton_Volatile()
    {
        Task.Delay(500);
        Singleton_Volatile instance = Singleton_Volatile.Instance;
    }

    static void Test_Singleton_Lock()
    {
        Task.Delay(500);
        Singleton_Lock instance = Singleton_Lock.Instance;
    }

    static void Test_Singleton_Lazy()
    {
        Task.Delay(500);
        Singleton_Lazy instance = Singleton_Lazy.Instance;
    }

}

