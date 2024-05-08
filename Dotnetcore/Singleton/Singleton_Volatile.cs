using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
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
    public sealed class Singleton_Volatile //rarely
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


}
