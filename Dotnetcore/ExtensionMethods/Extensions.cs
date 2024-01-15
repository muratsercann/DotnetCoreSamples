
namespace MyExtensions
{
    internal static class StringExtensions
    {
        public static bool IsNumeric(this string str)
        {
            return double.TryParse(str, out _);
        }

    }

    public static class ListExtensions
    {
        public static void AddRange<T>(this List<T> list, params T[] items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }
    }
}