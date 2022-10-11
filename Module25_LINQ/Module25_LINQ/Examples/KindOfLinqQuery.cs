using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот пример показывает как можно написать linq запросы
/// </summary>
public class KindOfLinqQuery : DataService
{
    public KindOfLinqQuery(DataStorage storage) : base(storage)
    {
    }

    public void PrintEmailsByLinqQuery()
    {
        var emails = from user in Users
                     select user.Email;

        emails.PrintItems();
    }

    public void PrintEmailsByExtensionMethods()
    {
        var emails = Users.Select(q => q.Email);

        emails.PrintItems();
    }
}