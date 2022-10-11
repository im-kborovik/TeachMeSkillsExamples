using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот метод показывает как мы можем сортировать дынные с помощью метода OrderBy и OrderByDescending
/// </summary>
public class Sorting : DataService
{
    public Sorting(DataStorage storage) : base(storage)
    {
    }

    public void SortUsersByEmailAsc()
    {
        Users.PrintItems("Before sorting");

        var sortedUsers = Users.OrderBy(q => q.Email);
        sortedUsers.PrintItems("After sorting");
    }

    public void SortUsersByEmailDesc()
    {
        Users.PrintItems("Before sorting");

        var sortedUsers = Users.OrderByDescending(q => q.Email);
        sortedUsers.PrintItems("After sorting");
    }
}