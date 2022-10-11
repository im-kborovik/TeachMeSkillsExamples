using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

public class Filtering : DataService
{
    public Filtering(DataStorage storage) : base(storage)
    {
    }

    public void PrintUsersMoreThenAge(int age)
    {
        Users.PrintUsers("Before filtering");

        var filteredUsers = Users.Where(q => q.Age > age);

        filteredUsers.PrintUsers("After filtering");
    }
}