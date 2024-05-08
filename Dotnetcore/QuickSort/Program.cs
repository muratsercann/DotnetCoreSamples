using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var random = new Random();

        //var numbers1 = Enumerable.Range(1, 1000000).OrderBy(x => random.Next()).Take(1000000).ToArray();
        var numbers1 = new int[]{ 2,5,1,6,4};
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Sort(numbers1, 0, numbers1.Length - 1);
        stopwatch.Stop();
        Console.WriteLine($"MyCode.Sort : {stopwatch.Elapsed.TotalMilliseconds} milisaniye ");

    }

    public static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            Sort(arr, left, pivot - 1);
            Sort(arr, pivot + 1, right);
        }
    }

    public static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int lastSmallerIndex = left;

        for (int i = left; i < right; i++)
        {
            if (arr[i] <= pivot)
            {
                Swap(arr, lastSmallerIndex, i);
                lastSmallerIndex++;
            }
        }
        Swap(arr, lastSmallerIndex, right);
        return lastSmallerIndex;
    }

    public static void Swap(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    public static class PerformanceTest
    {

        public static void Test1()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int counter = 0;
            for (int i = 0; i < 1000000; i++)
            {
                counter += 3;


            }
            watch.Stop();

            Console.WriteLine($"Test 1 in {watch.Elapsed.TotalMilliseconds} ms");
        }

        public static void Test2()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int counter = 0;
            for (int i = 0; i < 1000000; i++)
            {
                AddToCounter(ref counter);
            }
            watch.Stop();

            Console.WriteLine($"Test 2 in {watch.Elapsed.TotalMilliseconds} ms");
        }

        public static void AddToCounter(ref int counter)
        {
            counter += 3;
        }
    }
}