namespace Module32_Collections;

public class EnumerablePrinter
{
    public void PrintWithoutIEnumerable()
    {
        Console.WriteLine(nameof(EnumerableExampleWithoutIEnumerable));
        
        var enumerableExample = new EnumerableExampleWithoutIEnumerable();

        // демонстрация работы нашего итератора в foreach
        foreach (var item in enumerableExample)
        {
            Console.WriteLine(item);
        }

        // а так выглядит примерная реализация foreach под капотом
        var enumerator = enumerableExample.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
    
    public void PrintWithIEnumerable()
    {
        Console.WriteLine(nameof(EnumerableExampleWithIEnumerable));
        
        var enumerableExample = new EnumerableExampleWithIEnumerable();

        foreach (var item in enumerableExample)
        {
            Console.WriteLine(item);
        }

        var enumerator = enumerableExample.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
}
