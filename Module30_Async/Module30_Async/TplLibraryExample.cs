namespace Module30_Async;

public class TplLibraryExample
{
    public void SimpleTask()
    {
        // ----- Инициализация задачи

        // Первый вариант определения задачи
        var task1 = new Task(() => Console.WriteLine("Here is first task initialization approach"));
        task1.Start(); // в этом случае нужно всегда вызывать метод Start

        // Второй вариант определения задачи
        var task2 = Task.Factory.StartNew(() => Console.WriteLine("Here is second task initialization approach"));

        // Третий вариант определения задачи
        var task3 = Task.Run(() => Console.WriteLine("Here is third task initialization approach"));

        // ----- Ожидание завершения задачи

        // Одиночное ожидание задачи
        task1.Wait();
        task2.Wait();
        task3.Wait();

        // Так лучше использовать да и результат можно сразу достать, есть таска что-то возвращает
        task1.GetAwaiter().GetResult();
        task2.GetAwaiter().GetResult();
        task3.GetAwaiter().GetResult();

        // а так можно ожидать выполнение нескольких тасок
        Task.WaitAll(task1, task2, task3);
        Task.WaitAny(task1, task2, task3);
    }

    public void GenericTask()
    {
        // Но что, если нам нужно что-то вернуть из задачи
        // На этот случай есть обобщённые таски

        var range = Enumerable.Range(1, 10);
        
        Task<int> genericTask = Task.Run(() => range.Sum());
        
        var result = genericTask.GetAwaiter().GetResult();

        Console.WriteLine($"Result of generic task: {result}");
    }

    public void ContinuationTask()
    {
        // Нам нужно выполнить одну задачу за другой, причём сохраняя асинхронность
        var range = Enumerable.Range(1, 10);
        var counter = 1;
        var task = Task.Run(() => range.Sum())
                       .ContinueWith(resultFromPrevTask => Console.WriteLine($"Here is result in continuation task: {resultFromPrevTask.Result}")) // так мы можем определить, что выполнить после основной таски
                       .ContinueWith(q => Console.WriteLine($"Here is continuation: {counter++}")) // 1
                       .ContinueWith(q => Console.WriteLine($"Here is continuation: {counter++}")) // 2
                       .ContinueWith(q => Console.WriteLine($"Here is continuation: {counter++}")) // 3
                       .ContinueWith(q => Console.WriteLine($"Here is continuation: {counter++}")) // 4
                       .ContinueWith(q => Console.WriteLine($"Here is continuation: {counter++}")); // 5

        task.Wait();
    }
}