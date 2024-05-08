internal class Program
{
    private static void Main(string[] args)
    {
        var arr = new int[]{ 5, 2, 1, 6, 4, 8, 2,3,10,50,18,12,1,59,56,-5,74,48};

        Console.Write("Unsorted Array :");
        writeArray(arr);
        Sort(arr);
        Console.Write("Sorted Array :");
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
            int X = arr[i];
            int lastSkipped = i;
            
            for (int j = i - 1 ; j >= 0; j--)
            {
                if (X < arr[j])
                {
                    arr[j+1] = arr[j];
                    lastSkipped = j;
                }
                else
                {                    
                    break;
                }
            }

            arr[lastSkipped] = X;


        }
        return arr;
    }

    public static void Swap(int[] arr, int index1, int index2)
    {
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }
}