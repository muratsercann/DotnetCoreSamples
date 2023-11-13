using System.Collections;

namespace myProgram
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RunWorkerTest();
            // Console.WriteLine(".net core is everywhere...");
            // // Console.ReadLine();

            // ArrayList list = new ArrayList();
            // int a = 5;
            // int b = 4;
            // list.Add(a);
            // list.Add(b);

            // changeValue(list[0]);

            // Console.WriteLine("list[0] : " + list[0]);
            // Console.WriteLine("a : " + a);

            // changeList(list);

            // Console.WriteLine("After changeList is invoked : ");
            // Console.WriteLine("list[0] : " + list[0]);
            // Console.WriteLine("a : " + a);
        }

        private static void RunWorkerTest()
        {
            // Create the worker thread object. This does not start the thread.
            Worker workerObject = new Worker();
            Thread workerThread = new Thread(workerObject.DoWork);

            // Start the worker thread.
            workerThread.Start();
            Console.WriteLine("Main thread: starting worker thread...");

            // Loop until the worker thread activates.
            while (!workerThread.IsAlive)
                ;

            // Put the main thread to sleep for 500 milliseconds to
            // allow the worker thread to do some work.
            Thread.Sleep(500);

            // Request that the worker thread stop itself.
            workerObject.RequestStop();

            // Use the Thread.Join method to block the current thread
            // until the object's thread terminates.
            workerThread.Join();
            Console.WriteLine("Main thread: worker thread has terminated.");
        }
        private static void changeList(ArrayList arr)
        {
            arr[0] = 115;
        }

        private static void changeValue(object a)
        {
            a = 10;
        }
    }


    public class Worker
    {
        // This method is called when the thread is started.
        public void DoWork()
        {
            bool work = false;
            while (!_shouldStop)
            {
                work = !work; // simulate some work
            }
            Console.WriteLine("Worker thread: terminating gracefully.");
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Keyword volatile is used as a hint to the compiler that this data
        // member is accessed by multiple threads.
        private volatile bool _shouldStop;
    }

}

namespace myProgram.myNamespace1
{
    public class myClass
    {

    }

}

namespace myProgram.myNamespace2
{

    public class myClass
    {

    }

}