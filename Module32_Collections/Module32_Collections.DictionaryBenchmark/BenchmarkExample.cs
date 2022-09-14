using BenchmarkDotNet.Attributes;

namespace Module32_Collections.DictionaryBenchmark;

public class BenchmarkExample
{
    private readonly List<string> _list = new List<string>();
    private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

    private readonly string finding;

    public BenchmarkExample()
    {
        for (var i = 0; i < 1_000_000; i++)
        {
            var value = Guid.NewGuid().ToString();
            _list.Add(value);
            _dictionary.Add(value, value);
            if (i == 500_000)
            {
                finding = value;
            }
        }
    }
    
    /// <summary>
    /// Проверяем скорость работы поиска по ключу у Dictionary
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public bool DictionaryContainsKey()
    {
        return _dictionary.ContainsKey(finding);
    }
    
    /// <summary>
    /// Проверяем скорость работы поиска по значению у Dictionary
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public bool DictionaryContainsValue()
    {
        return _dictionary.ContainsValue(finding);
    }

    /// <summary>
    /// Проверяем скорость работы поиска по значению у List
    /// </summary>
    /// <returns></returns>
    [Benchmark]
    public bool List()
    {
        return _list.Contains(finding);
    }
}