
//https://learn.microsoft.com/en-us/previous-versions/msp-n-p/ff650316(v=pandp.10)?redirectedfrom=MSDN
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

    /// <summary>
    /// The instantiation is not performed 
    /// until an object asks for an instance; 
    /// this approach is referred to as lazy instantiation. 
    /// Lazy instantiation avoids instantiating unnecessary singletons 
    /// when the application starts.
    /// 
    /// The main disadvantage of this implementation, 
    /// however, is that it is not safe for multithreaded environments. 
    /// If separate threads of execution enter the Instance property 
    /// method at the same time, more that one instance of the Singleton_WithoutLock
    /// object may be created. Each thread could execute the following statement
    /// and decide that a new instance has to be created:
    /// </summary>
    public class Singleton_WithoutLock
    {
        private static Singleton_WithoutLock instance;

        private Singleton_WithoutLock() { }

        public static Singleton_WithoutLock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton_WithoutLock();
                    Console.WriteLine("Instance has been created by Thread " + Thread.CurrentThread.ManagedThreadId);
                }
                return instance;
            }
        }
    }


    public sealed class Singleton_Lock
    {
        public static Singleton_Lock instance;// = new Singleton_Lock();
        private static readonly object lockObject = new object();

        private DateTime createdAt;
        public DateTime CreatedAt => createdAt;
        private Singleton_Lock()
        {
            createdAt = DateTime.Now;
            Console.WriteLine("Instance has been created by Thread " + Thread.CurrentThread.ManagedThreadId);
        }

        public static Singleton_Lock Instance
        {
            get
            {
                // Uses lazy initialization.
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        //if(instance == null)
                        instance = new Singleton_Lock();
                    }
                }

                return instance;
            }
        }
    }

    /// <summary>
    /// In this strategy, the instance is created 
    /// the first time any member of the class is referenced. 
    /// 
    /// The common language runtime takes care of the variable initialization.
    /// 
    /// In addition, the variable is marked readonly, 
    /// which means that it can be assigned only during 
    /// static initialization (which is shown here) or in a class constructor.
    /// 
    /// The only potential downside of this approach is that 
    /// you have less control over the mechanics of the instantiation. 
    /// In the Design Patterns form, you were able to use 
    /// a nondefault constructor or perform other tasks before the instantiation.
    /// Because the .NET Framework performs the initialization in this solution, 
    /// you do not have these options. 
    /// In most cases, static initialization is the preferred approach 
    /// for implementing a Singleton_WithoutLock in .NET
    /// </summary>
    public sealed class Singleton_StaticInitialization
    {
        private static readonly Singleton_StaticInitialization
           instance = CreateInstance(); //new Singleton_StaticInitialization();

        private static Singleton_StaticInitialization CreateInstance()
        {
            Console.WriteLine("Instance has been created by Thread " + Thread.CurrentThread.ManagedThreadId);

            return new Singleton_StaticInitialization();
        }
        private Singleton_StaticInitialization()
        {

        }

        public static Singleton_StaticInitialization Instance
        {
            get
            {
                return instance;
            }
        }


    }

    /// <summary>
    /// Multithreaded Singleton_WithoutLock (Double check)
    /// 
    /// This double-check locking approach solves 
    /// the thread concurrency problems 
    /// while avoiding an exclusive lock in every call to
    /// the Instance property method. It also allows you to
    /// delay instantiation until the object is first accessed. 
    /// In practice, an application rarely requires this type of implementation. 
    /// 
    /// In most cases, the static initialization approach is sufficient.
    /// 
    /// https://stackoverflow.com/questions/12316406/thread-safe-c-sharp-singleton-pattern#:~:text=Performing%20the%20lock%20is,also%20evaluates%20other%20alternatives.
    /// </summary>
    public sealed class Singleton_Volatile
    {
        private static volatile Singleton_Volatile instance;
        private static object syncRoot = new Object();

        private Singleton_Volatile() { }

        public static Singleton_Volatile Instance
        {
            get
            {

                if (instance == null) //double chack
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton_Volatile();
                            Console.WriteLine("Instance has been created by Thread " + Thread.CurrentThread.ManagedThreadId);
                        }
                    }
                }

                return instance;
            }
        }
    }


    public sealed class Singleton_Lazy
    {
        private static readonly Lazy<Singleton_Lazy> lazyInstance =
            new Lazy<Singleton_Lazy>(() => new Singleton_Lazy(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static Singleton_Lazy Instance => lazyInstance.Value;

        private DateTime createdAt;
        public DateTime CreatedAt => createdAt;

        private Singleton_Lazy()
        {
            createdAt = DateTime.Now;
            Console.WriteLine("Instance has been created by Thread " + Thread.CurrentThread.ManagedThreadId);
        }


    }
}

