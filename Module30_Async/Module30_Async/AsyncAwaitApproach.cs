namespace Module30_Async;

/// <summary>
///     Данный пример показывает как использовать асинхронные методы в c#
/// </summary>
public class AsyncAwaitApproach
{
    // Для использования асинхронных методов нам нужны три вещи
    // Пометить метод async словом, указать в качестве возвращаемого типа Task или Task<>
    public async Task FirstAsyncMethod()
    {
        await SecondAsyncMethod(); // перед методами, которые вызываются асинхронно внутри текущего, поставить await
        await SecondAsyncMethod(); // таких методов может быть сколько угодно, НО не забывайте перед ними ставить await
        await SecondAsyncMethod(); // зачем? посмотрите на метод NotAwaitableTask, попробуйте запустить его несколько раз и посмотрите на консоль
        
        // У таких методов есть ограничение. Асинхронный метод не может определять параметры с модификаторами out, ref и in
    }

    private Task SecondAsyncMethod()
    {
        return Task.Run(() => Console.WriteLine($"Here is second method of async park: {Enumerable.Range(1, 10).Sum()}"));
    }

    public Task NotAwaitableTask()
    {
        WriteInt(1);
        WriteInt(2);
        WriteInt(3);

        return Task.Delay(2000);
    }

    private Task WriteInt(int value)
    {
        return Task.Run(() => Console.WriteLine($"Write Int: {value}"));
    }

    public async Task ParallelExecution()
    {
        // Ещё одним полезнам инструментом асинхронности является параллельное выполнение
        var tasks = new Task[]
                   {
                       Task.Run(() => Console.WriteLine("Допустим")),
                       Task.Run(() => Console.WriteLine("нам не важен")),
                       Task.Run(() => Console.WriteLine("результат.")),
                       Task.Run(() => Console.WriteLine("В этом")),
                       Task.Run(() => Console.WriteLine("случае")),
                       Task.Run(() => Console.WriteLine("мы можем")),
                       Task.Run(() => Console.WriteLine("запустить")),
                       Task.Run(() => Console.WriteLine("несколько")),
                       Task.Run(() => Console.WriteLine("задач")),
                       Task.Run(() => Console.WriteLine("параллельно")),
                       Task.Run(() => Console.WriteLine("и ждать")),
                       Task.Run(() => Console.WriteLine("их выполнения.")),
                   };
        await Task.WhenAll(tasks); // а теперь запустите и посмотрите на консоль :)
    }
}