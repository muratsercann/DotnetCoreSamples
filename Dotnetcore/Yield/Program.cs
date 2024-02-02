using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        foreach (int i in ProduceEvenNumbers(9))
        {
            Console.Write(i);
            Console.Write(" ");
        }
        // Output: 0 2 4 6 8
        IEnumerable<int> ProduceEvenNumbers(int upto)
        {
            for (int i = 0; i <= upto; i += 2)
            {
                yield return i;
            }
        }

        Console.WriteLine(string.Join(" ", TakeWhilePositive([2, 3, 4, 5, -1, 3, 4])));
        // Output: 2 3 4 5

        IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
        {
            foreach (int n in numbers)
            {
                if (n > 0)
                {
                    yield return n;
                }
                else
                {
                    yield break;
                }
            }
        }
    }
}
