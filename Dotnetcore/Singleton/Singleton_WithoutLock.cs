using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
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
}
