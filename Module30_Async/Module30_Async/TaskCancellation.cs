namespace Module30_Async;

// А что если нам нужно отменить выполнение асинхронного метода?
public class TaskCancellation
{
    // Для этого есть механизм отмены выполнения тасок, который основан на подходе специальных токенов
    public async Task RunCancellationExample()
    {
        const int delay = 3000;
        
        // создадим ресурс токенов, который позволяет нам управлять токеном отмены
        var source1 = new CancellationTokenSource();
        TaskWithCancellation(source1.Token, 1);

        await Task.Delay(delay); // подождём 3 секунды и закончим 
        source1.Cancel();
        
        await TaskWithCancellation(source1.Token, 2);

        // а можно вот так закончить работу задачи
        var source2 = new CancellationTokenSource(delay);
        await TaskWithCancellation(source2.Token, 3);
    }
    
    private async Task TaskWithCancellation(CancellationToken cancellationToken, int i)
    {        
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"{nameof(TaskWithCancellation)} is cancelled {i}");
            return;
        }

        await Task.Delay(5000);

        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine($"{nameof(TaskWithCancellation)} is cancelled after waiting {i}");
            return;
        }

        Console.WriteLine($"{nameof(TaskWithCancellation)} is still in progress");
    }
}