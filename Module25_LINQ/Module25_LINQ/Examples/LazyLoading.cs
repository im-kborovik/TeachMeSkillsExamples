using Module25_LINQ.Common;
using Module25_LINQ.Data;

namespace Module25_LINQ.Examples;

/// <summary>
/// Этот пример показывает как работает lazy loading в linq
/// </summary>
public class LazyLoading : DataService
{
    public LazyLoading(DataStorage storage) : base(storage)
    {
    }

    public void Example()
    {
        var print = "We don't have value :(";

        var emails = Users.Select(q =>
                                  {
                                      print = "Hey! We got a value!";
                                      return q.Email;
                                  });
        Console.WriteLine(print);

        var array = emails.ToArray();

        Console.WriteLine(print);
    }
}