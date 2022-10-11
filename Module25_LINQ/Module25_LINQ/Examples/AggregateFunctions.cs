using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот пример показывает использование агрегатных функций
/// </summary>
public class AggregateFunctions : DataService
{
    public AggregateFunctions(DataStorage storage) : base(storage)
    {
    }

    public void Aggregate()
    {
        var intValues = new[]
                        {
                            1,
                            2,
                            3,
                            4
                        };
        var result = intValues.Aggregate((q, w) => q + w);
        Console.WriteLine($"Result: {result}");
    }

    public void MaxMinAvgSum()
    {
        var min = Products.Min(q => q.Price);
        var max = Products.Max(q => q.Price);
        var avg = Products.Average(q => q.Price);
        var sum = Products.Sum(q => q.Price);

        Console.WriteLine($"Here is min price {min}, max price {max}, average price {avg} and price sum {sum}");
    }

    public void Count()
    {
        var avg = Users.Average(q => q.FirstName.Length);
        var usersWithLongFirstNameCount = Users.Count(q => q.FirstName.Length > avg);
        var usersWithLongFirstName = Users.Where(q => q.FirstName.Length > avg).ToArray();

        usersWithLongFirstName.PrintItems();

        Console.WriteLine($"Users count: {usersWithLongFirstNameCount}");
    }
}