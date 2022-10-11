using Module25_LINQ.Common;
using Module25_LINQ.Data;

namespace Module25_LINQ.Examples;

public class KindOfLinqQuery : DataService
{
    public KindOfLinqQuery(DataStorage storage) : base(storage)
    {
    }

    public void PrintEmailsByLinqQuery()
    {
        var emails = from user in Users
                     select user.Email;

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }

    public void PrintEmailsByExtensionMethods()
    {
        var emails = Users.Select(q => q.Email);

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}