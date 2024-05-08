using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
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
