using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class FactorialTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">The number for which the factorial will be calculated. </param>
        /// <param name="lengthOfEachfragments">sayıyı kaçlık parçalara böleceğimizin parametresi</param>
        /// <returns></returns>
        public static async Task CalculateFactorials(int number, int lengthOfEachfragments)
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            List<Task<BigInteger>> tasks = CreateTaskList(number, lengthOfEachfragments);
            BigInteger[] results = await Task.WhenAll(tasks);
            w.Stop();
            Console.WriteLine($"Multi Thread Finished in {w.Elapsed.TotalMilliseconds} ms ({number},{lengthOfEachfragments}) ({results.Length} fragment)");
            //Console.WriteLine($"Multi Thread result : {Multiply(results)}");
        }

        public static void RunConcurently(ConcurrentBag<BigInteger> collection, int start, int end)
        {
            var processId = Process.GetCurrentProcess().Id;
            var threadId = Thread.CurrentThread.ManagedThreadId;
            var proccessorId = System.Threading.Thread.GetCurrentProcessorId();

            var result = Multiply(start, end);
            collection.Add(result);


            Console.WriteLine($"({start},{end}),Processor Id ({processId}), Process Id ({processId}), Thread Id ({threadId}, result : {result})");

        }

        /// <summary>
        /// Creates task list for factorial calculation. 
        /// Each task multiplies the number amount specified with lengthOfEachfragments 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="lengthOfEachfragments"></param>
        /// <returns></returns>
        private static List<Task<BigInteger>> CreateTaskList(int number, int lengthOfEachfragments)
        {
            List<Task<BigInteger>> tasks = new List<Task<BigInteger>>();

            int taskNumber = number % lengthOfEachfragments == 0 ? number / lengthOfEachfragments : number / lengthOfEachfragments + 1;
            for (int i = 0; i < taskNumber; i++)
            {
                int first = (i * lengthOfEachfragments) + 1;
                int last = first + (lengthOfEachfragments - 1);
                if (last > number)
                    last = number;

                tasks.Add(Task.Run(() => Multiply(first, last)));
            }

            return tasks;
        }

        public static BigInteger Multiply(int fromNumber, int toNumber)
        {
            BigInteger result = 1;
            for (int i = fromNumber; i <= toNumber; i++)
            {
                Thread.Sleep(30);
                result *= i;
            }

            return result;
        }
        public static BigInteger Multiply(params BigInteger[] numbers)
        {
            BigInteger result = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                result *= numbers[i];
            }
            return result;
        }


    }
}
