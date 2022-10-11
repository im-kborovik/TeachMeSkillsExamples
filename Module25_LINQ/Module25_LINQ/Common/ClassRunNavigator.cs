using System.Linq.Expressions;
using Module25_LINQ.Helpers;

namespace Module25_LINQ.Common;

public class ClassRunNavigator<T>
{
    private readonly ClassRunner _runner;
    private readonly T _instance;

    public ClassRunNavigator(ClassRunner runner, T instance)
    {
        _runner = runner;
        _instance = instance;
    }

    public ClassRunNavigator<T> Use(Expression<Action<T>> invoker)
    {
        var methodExpression = invoker.Body as MethodCallExpression;

        Console.WriteLine($"Use method: {methodExpression!.Method.Name}");

        invoker.Compile().Invoke(_instance);

        Underline();
        return this;
    }

    public ClassRunner ReturnToRunner()
    {
        Console.WriteLine($"Stop use class: {typeof(T).Name}");
        return _runner;
    }

    public ClassRunNavigator<T> Underline()
    {
        Underliner.Underline();
        return this;
    }
}