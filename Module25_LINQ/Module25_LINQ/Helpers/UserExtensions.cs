using Module25_LINQ.Data.Entities;

namespace Module25_LINQ.Helpers;

public static class UserExtensions
{
    public static void PrintUsers(this IEnumerable<User> users, string messageBefore = null)
    {
        if (!string.IsNullOrEmpty(messageBefore))
        {
            Console.WriteLine(messageBefore);
        }
        
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}