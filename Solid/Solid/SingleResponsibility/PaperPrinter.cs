namespace Solid.SingleResponsibility;

public class PaperPrinter : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Печать на принтер");
    }
}