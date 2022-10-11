using Module25_LINQ.Common;
using Module25_LINQ.Data;

namespace Module25_LINQ.Examples;

public class WorkingWithSomeCollections : DataService
{
    private readonly string[] _firstArray =
    {
        "0",
        "1",
        "2",
        "3"
    };

    private readonly string[] _secondArray =
    {
        "2",
        "3",
        "4",
        "5"
    };

    public WorkingWithSomeCollections(DataStorage storage) : base(storage)
    {
    }

    public void Join()
    {
        var userProducts = Users.Join(Products,
                                      q => q.Email,
                                      q => q.Email,
                                      (q, w) => new
                                                {
                                                    User = q,
                                                    Product = w
                                                });
        foreach (var userProduct in userProducts)
        {
            Console.WriteLine($"User: {userProduct.User}\nProduct: {userProduct.Product}");
            Console.WriteLine();
        }
    }

    public void GroupBy()
    {
        var result = Products.GroupBy(q => q.Email);
        foreach (var userProducts in result)
        {
            Console.WriteLine($"For email: {userProducts.Key} we have next products (count: {userProducts.Count()})");
            foreach (var userProduct in userProducts)
            {
                Console.WriteLine(userProduct);
            }
        }
    }

    public void Intersect()
    {
        var result = _firstArray.Intersect(_secondArray);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    public void Except()
    {
        var result = _firstArray.Except(_secondArray);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    public void Distinct()
    {
        var result = _firstArray.Except(_secondArray);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    public void Union()
    {
        var result = _firstArray.Union(_secondArray);
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}