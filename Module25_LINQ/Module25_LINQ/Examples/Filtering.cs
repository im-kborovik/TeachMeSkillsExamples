using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот пример показывает как мы можем фильтровать даынные с помощью методы Where.
/// </summary>
public class Filtering : DataService
{
    public Filtering(DataStorage storage) : base(storage)
    {
    }

    public void PrintUsersMoreThenAge(int age)
    {
        Users.PrintItems("Before filtering");

        var filteredUsers = Users.Where(q => q.Age > age);

        filteredUsers.PrintItems("After filtering");
    }
}