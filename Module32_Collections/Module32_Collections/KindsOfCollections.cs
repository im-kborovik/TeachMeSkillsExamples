using System.Collections;

namespace Module32_Collections;

public class KindsOfCollections
{
    /// <summary>
    /// Коллекция, которая состоит из пар клю-значение.
    /// По сути представляет обычную реализацию структуры Словарь.
    /// Под капотом в качестве ключей использует хэши, которые получаются с помощью метода GetHashCode (он есть в каждом объекте)
    /// Проблема этой коллекции - и ключи и значения добавляются как тип object, т.е. для значимых типов происходит boxing|unboxing
    /// Ключи не должны повторяться иначе выкидывает исключение.
    /// </summary>
    public void Hashtable()
    {
        var hashtable = new Hashtable();
        hashtable.Add(1, "first");
        hashtable.Add(2, "second");
        hashtable.Add(3, "third");

        Console.WriteLine(nameof(Hashtable));

        foreach (DictionaryEntry item in hashtable)
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
        
        if (hashtable.ContainsKey(1))
        {
            Console.WriteLine($"Here is value with key is equaled 1: {hashtable[1]}");
        }
    }

    /// <summary>
    /// Коллекция, которая всегда сортирует элементы по ключу.
    /// Очень похож на Hashtable, потому что требует ключ и значение при добавлении элемента.
    /// Ключи не должны повторяться иначе выкидывает исключение.
    /// </summary>
    public void SortedList()
    {
        var sortedList = new SortedList();
        sortedList.Add(2, "Here is 2");
        sortedList.Add(1, "Here is 1");
        sortedList.Add(5, "Here is 5");

        Console.WriteLine(nameof(SortedList));

        foreach (DictionaryEntry item in sortedList) // тут выведется отсортированные эелементы 1, 2, 5
        {
            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
        }
    }

    /// <summary>
    /// Коллекция, которая позволяет не следить за размерностью массива.
    /// Принимает в качестве элементов object. То есть мы можем положить сюда разнотипные объекты
    /// </summary>
    public void ArrayList()
    {
        var arrayList = new ArrayList();
        arrayList.Add(1);
        arrayList.Add(2);
        arrayList.Add(3);

        Console.WriteLine(nameof(ArrayList));

        foreach (var item in arrayList)
        {
            Console.WriteLine($"Value: {item}");
        }
    }

    /// <summary>
    /// Коллекция, которая работает по принципу "первый вошёл, первый вышел"
    /// </summary>
    public void Queue()
    {
        var queue = new Queue();
        queue.Enqueue(3);
        queue.Enqueue(1);
        queue.Enqueue(2);

        Console.WriteLine(nameof(Queue));

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            Console.WriteLine($"Value: {item}"); // result 3, 1, 2
        }
    }

    /// <summary>
    /// Коллекция, которая работает по принципу "первый вошёл, последний вышел"
    /// </summary>
    public void Stack()
    {
        var stack = new Stack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Console.WriteLine(nameof(Stack));

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            Console.WriteLine($"Value: {item}"); // result 3, 2, 1
        }
    }
}