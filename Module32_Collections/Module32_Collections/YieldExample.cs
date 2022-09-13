using System.Collections;

namespace Module32_Collections;

/// <summary>
/// Как работает ключевое слово yield
/// </summary>
public class YieldExample : IEnumerable
{
    private readonly string[] _cats =
    {
        "first cat",
        "second cat",
        "third cat"
    };

    /// <summary>
    /// Применяя yield мы можем вернуть IEnumerator тип
    /// В этом случае сам метод лучше назвать GetEnumerator, чтобы включить возможность передачи в foreach целого экземпляра класса
    /// </summary>
    /// <returns></returns>
    public IEnumerator GetEnumerator()
    {
        for (var i = 0; i < _cats.Length; i++)
        {
            yield return _cats[i];
        }
    }

    /// <summary>
    /// А можем вернуть и IEnumerable
    /// В этом случае мы не сможем передать экземпляр класс в foreach. Мы должны напрямую вызывать метод и передавать результат в foreach
    /// Всё зависит от того, чего мы хоти добиться:
    /// Мы хотим передавать в foreach целый класс для итерирования (IEnumerator) или нам достаточно одного метода в нём (IEnumerable)
    /// </summary>
    /// <returns></returns>
    public IEnumerable GetEnumerable()
    {
        for (var i = 0; i < _cats.Length; i++)
        {
            yield return _cats[i];
        }
    }

    public void PrintGetEnumerator()
    {
        Console.WriteLine(nameof(YieldExample));
        Console.WriteLine(nameof(PrintGetEnumerator));

        // var @enum = this.GetEnumerator();
        foreach (var cat in this)
        {
            Console.WriteLine(cat);
        }
    }

    public void PrintGetEnumerable()
    {
        Console.WriteLine(nameof(YieldExample));
        Console.WriteLine(nameof(PrintGetEnumerable));

        foreach (var cat in GetEnumerable())
        {
            Console.WriteLine(cat);
        }
    }
}