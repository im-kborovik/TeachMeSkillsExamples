namespace Solid.SingleResponsibility;

public class ConsolePrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Распечатать!");
    }
}