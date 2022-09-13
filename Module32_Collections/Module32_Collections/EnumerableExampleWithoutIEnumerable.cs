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

    public void Reset()
    {
        _currIndex = StartIndex;
    }

    public object Current => _current;
}

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
