using Module25_LINQ.Data.Entities;

namespace Module25_LINQ.Helpers;

public static class UserExtensions
{
    public static void PrintItems<T>(this IEnumerable<T> source, string messageBefore = null)
    {
        if (!string.IsNullOrEmpty(messageBefore))
        {
            Console.WriteLine(messageBefore);
        }
        
        foreach (var item in source)
        {
            Console.WriteLine(item);
        }
    }
}