using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
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
}
