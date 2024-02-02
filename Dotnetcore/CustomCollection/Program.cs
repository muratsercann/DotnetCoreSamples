using IteratingCustomCollection;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {

        Item[] items = [
            new Item("id1", "n1"),
            new Item("id2", "n2")];

        IEnumerable<Item> list = new MyGenericCollection<Item>(items);

        Console.WriteLine($"IEnumerable<T> {list.GetType()}");
        foreach (Item p in list)
            Console.WriteLine(p.Id + " " + p.Name);

        Console.WriteLine();

        IEnumerable nonGenericEnumerable = list;
        Console.WriteLine($"IEnumerable (non-generic) :{nonGenericEnumerable.GetType()}");
        foreach (Item p in nonGenericEnumerable)
            Console.WriteLine(p.Id + " " + p.Name);

    }
}

