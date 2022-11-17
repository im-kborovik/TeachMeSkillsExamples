namespace Solid.SingleResponsibility;

/// <summary>
/// Принцип single responsibility нам говорит о том, что мы должны проектировать классы таким образом,
/// чтобы они имели только одну ответственности. Таким образом это будет приводить к потенциально меньшему количеству багов при его изменении. 
/// </summary>
public class Report
{
    private readonly IPrinter _printer;

    public Report(IPrinter printer)
    {
        _printer = printer;
    }
    
    public void MoveNext()
    {
        Console.WriteLine("Идём на сл страницу");
    }

    public void MovePrevPage()
    {
        Console.WriteLine("Идём на пред станицу");
    }

    public void MoveFirstPage()
    {
        Console.WriteLine("Идём на первую страницу");
    }

    public void MoveLastPage()
    {
        Console.WriteLine("Идём на последнюю страницу");
    }
    
    // пример сильной связанности и нарушения принципа single responsibility
    // public void Print()
    // {
    //     Console.WriteLine("Распечатать!");
    // }

    // пример как это пофиксить: разделить обязанности классов
    public void Print()
    {
        _printer.Print();
    }
}