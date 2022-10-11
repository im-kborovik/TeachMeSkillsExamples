using Module25_LINQ.Common;
using Module25_LINQ.Data;

namespace Module25_LINQ.Examples;

public class ElementContaining : DataService
{
    public ElementContaining(DataStorage storage) : base(storage)
    {
    }

    public void Any()
    {
        var avg = Products.Average(q => q.Price);
        var existProductWithAvgPrice = Products.Any(q => q.Price == avg);
        Console.WriteLine($"Do products have product with avg price {avg}? {existProductWithAvgPrice}");
    }

    public void All()
    {
        var allUsersOlder18 = Users.All(q => q.Age > 18);
        Console.WriteLine($"Are all users older 18? {allUsersOlder18}");
    }

    public void Contains()
    {
        var has18Age = Users.Select(q => q.Age).Contains(18);
        Console.WriteLine($"Do we have users with age equals 18? {has18Age}");
    }

    public void FirstAndSingle()
    {
        var min = Users.Min(q => q.Age);
        var firstUserWithMinAge = Users.FirstOrDefault(q => q.Age == min);
        if (firstUserWithMinAge is not null)
        {
            Console.WriteLine(firstUserWithMinAge);
        }
        else
        {
            Console.WriteLine($"We didn't have users with min {min} age");
        }

        var userByEmail = Users.SingleOrDefault(q => q.Email == "test@test.com");
        Console.WriteLine($"Is user by email null? {userByEmail is null}");
    }
}