using Module25_LINQ.Data;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Common;

public class ClassRunner
{
    private readonly DataStorage _storage = new();

    public ClassRunNavigator<T> Run<T>()
        where T : DataService
    {
        var instance = Activator.CreateInstance(typeof(T), _storage);

        Console.WriteLine();
        Console.WriteLine($@"Start to use class: {typeof(T).Name}");
        Underline();

        return new ClassRunNavigator<T>(this, (T)instance!);
    }
    
    public ClassRunner Underline()
    {
        Underliner.Underline();
        return this;
    }
}