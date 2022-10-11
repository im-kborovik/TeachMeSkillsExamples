using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

public class Sorting : DataService
{
    public Sorting(DataStorage storage) : base(storage)
    {
    }

    public void SortUsersByEmailAsc()
    {
        Users.PrintUsers("Before sorting");

        var sortedUsers = Users.OrderBy(q => q.Email);
        sortedUsers.PrintUsers("After sorting");
    }

    public void SortUsersByEmailDesc()
    {
        Users.PrintUsers("Before sorting");

        var sortedUsers = Users.OrderByDescending(q => q.Email);
        sortedUsers.PrintUsers("After sorting");
    }
}