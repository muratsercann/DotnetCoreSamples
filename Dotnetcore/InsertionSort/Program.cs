internal class Program
{
    private static void Main(string[] args)
    {
        var arr = new int[] { 5, 2, 1, 6, 4, 8, 2, 3, 10, 50, 18, 12, 1, 59, 56, -5, 74, 48, 0, 18 };

        Console.WriteLine("Unsorted Array :");
        writeArray(arr);
        Sort(arr);
        Console.WriteLine("\nSorted Array :");
        writeArray(arr);

        Console.ReadLine();       
    }

    private static void writeArray(int[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    private static int[] Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int currentValue = arr[i];
            int emptyIndex = i;

            for (int j = i - 1; j >= 0; j--)
            {
                if (currentValue < arr[j])
                {
                    MoveToRight(arr, j);
                    emptyIndex = j;
                }
                else
                    break;
            }
            arr[emptyIndex] = currentValue;
        }
        return arr;
    }

    public static void MoveToRight(int[] arr, int index)
    {
        arr[index + 1] = arr[index];
    }
}