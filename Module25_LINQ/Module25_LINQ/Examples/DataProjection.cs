using Module25_LINQ.Common;
using Module25_LINQ.Data;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот пример показывает как мы можем трансформировать выходные данные с помощью метода Select.
/// Этот подход называется проекцией данных.
/// </summary>
public class DataProjection : DataService
{
    public DataProjection(DataStorage storage) : base(storage)
    {
    }

    public void PrintFirstAndLastNames()
    {
        var firstAndLastNames = Users.Select(q => new
                                                  {
                                                      q.FirstName,
                                                      q.LastName
                                                  });
        foreach (var firstAndLastName in firstAndLastNames)
        {
            Console.WriteLine($"First Name: {firstAndLastName.FirstName} and Last Name: {firstAndLastName.LastName}");
        }
    }

    public void FillAddressForUsers()
    {
        var usersWithAddresses = Users.Select(q =>
                                              {
                                                  q.Address = DataStorage.CreateAddress();

                                                  Console.WriteLine(q.Address);

                                                  return q;
                                              })
                                      .ToArray();
    }
}