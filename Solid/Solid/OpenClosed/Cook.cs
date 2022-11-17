namespace Solid.OpenClosed;

public class Cook : ICooker
{
    public void Make()
    {
        Console.WriteLine("Достать овсянку.");
        Console.WriteLine("Залить молоко.");
        Console.WriteLine("Засыпать овсянку");
        Console.WriteLine("Размешать");
        Console.WriteLine("Приготовить");
    }
}