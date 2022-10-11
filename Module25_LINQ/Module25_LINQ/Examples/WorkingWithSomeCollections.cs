using Module25_LINQ.Common;
using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот пример показывает как мы можем взаимодействовать с двумя коллекциями
/// </summary>
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

    /// <summary>
    /// Join очень похож на аналогичный из SQL. Соединяет две коллекции по одному полю.
    /// </summary>
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

    /// <summary>
    /// GroupBy группирует по одному полю в рещультате получает что-то типа dictionary,
    /// у которого в качестве ключа выступает значение указанного поля, а в качестве value -
    /// группа объектов, у которых есть данное значение. 
    /// </summary>
    public void GroupBy()
    {
        var result = Products.GroupBy(q => q.Email);
        foreach (var userProducts in result)
        {
            Console.WriteLine($"For email: {userProducts.Key} we have next products (count: {userProducts.Count()})");

            userProducts.PrintItems();
        }
    }

    /// <summary>
    /// Пересечение множеств
    /// </summary>
    public void Intersect()
    {
        var result = _firstArray.Intersect(_secondArray);
        
        result.PrintItems();
    }

    /// <summary>
    /// Разность множеств
    /// </summary>
    public void Except()
    {
        var result = _firstArray.Except(_secondArray);

        result.PrintItems();
    }

    /// <summary>
    /// Удаление дубликатов
    /// </summary>
    public void Distinct()
    {
        var result = _firstArray.Except(_secondArray);
        
        result.PrintItems();
    }

    /// <summary>
    /// Объединение двух однотипных коллекций в одну
    /// </summary>
    public void Union()
    {
        var result = _firstArray.Union(_secondArray);
        
        result.PrintItems();
    }
}