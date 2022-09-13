using System.Collections;

namespace Module32_Collections;

/// <summary>
/// Классический пример реализации IEnumerator почти в любой коллекции
/// </summary>
public class EnumerableExampleWithIEnumerable : IEnumerable
{
    private readonly string[] _cats =
    {
        "first cat",
        "second cat",
        "third cat"
    };

    public int Count => _cats.Length;

    public object this[int index]
    {
        get => _cats[index];
        set => _cats[index] = value as string;
    }

    public IEnumerator GetEnumerator()
    {
        return new EnumeratorExample(this);
    }
}

/// <summary>
/// Это итератор, который содержит информацию о текущей итерации цикла
/// Если вы знакомы с паттерном проектирования Итератор, то этот класс в связке с IEnumerable его классическая реализация
/// </summary>
public class EnumeratorExample : IEnumerator
{
    private const int StartIndex = 0;

    private readonly EnumerableExampleWithIEnumerable _enumerableExampleWithoutIEnumerable;
    private int _currIndex = StartIndex;
    private object _current;

    public EnumeratorExample(EnumerableExampleWithIEnumerable enumerableExampleWithoutIEnumerable)
    {
        _enumerableExampleWithoutIEnumerable = enumerableExampleWithoutIEnumerable;
    }

    /// <summary>
    /// Переход к следующей итерации
    /// </summary>
    /// <returns></returns>
    public bool MoveNext()
    {
        if (_enumerableExampleWithoutIEnumerable.Count > _currIndex)
        {
            _current = _enumerableExampleWithoutIEnumerable[_currIndex];
            _currIndex++;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Сбрасывание итераций к первоначальному состоянию 
    /// </summary>
    public void Reset()
    {
        _currIndex = StartIndex;
        _current = null;
    }

    public object Current => _current;
}

/// <summary>
/// Пример того, что классы могут и не реализовывать интерфейс IEnumerable.
/// Достаточно добавить метод GetEnumerator и объект класса уже можно передавать в foreach.
/// </summary>
public class EnumerableExampleWithoutIEnumerable
{
    private readonly string[] _cats =
    {
        "first cat",
        "second cat",
        "third cat"
    };

    public IEnumerator GetEnumerator()
    {
        return _cats.GetEnumerator();
    }
}
