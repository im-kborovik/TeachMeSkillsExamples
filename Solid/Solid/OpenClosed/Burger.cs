namespace Solid.OpenClosed;

public class Burger : ICooker
{
    public void Make()
    {
        Console.WriteLine("Достать колбасу.");
        Console.WriteLine("Достать булочки.");
        Console.WriteLine("Достать сыр.");
        Console.WriteLine("Приготовить");
    }
}