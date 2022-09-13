using System.Collections;

namespace Module32_Collections;

public class YieldExample : IEnumerable
{
    private readonly string[] _cats =
    {
        "first cat",
        "second cat",
        "third cat"
    };

    public IEnumerator GetEnumerator()
    {
        for (var i = 0; i < _cats.Length; i++)
        {
            yield return _cats[i];
        }
    }

    public void Print()
    {
        Console.WriteLine(nameof(YieldExample));

        foreach (var cat in this)
        {
            Console.WriteLine(cat);
        }
    }
}

public class YieldExampleWithBreak : IEnumerable
{
    private readonly string[] _cats =
    {
        "first cat",
        "second cat",
        "third cat"
    };

    public IEnumerator GetEnumerator()
    {
        for (var i = 0; i < _cats.Length; i++)
        {
            if (i == 2)
            {
                yield break;
            }

            yield return _cats[i];
        }
    }

    public void Print()
    {
        Console.WriteLine(nameof(YieldExampleWithBreak));

        // тут получим только два из трёх элементов, потому что для третьего будет break.
        foreach (var cat in this)
        {
            Console.WriteLine(cat);
        }
    }
}