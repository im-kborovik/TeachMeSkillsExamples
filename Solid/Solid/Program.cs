using System.Text;
using Solid.InterfaceSegregation;
using Solid.Liskov;
using Solid.OpenClosed;
using Solid.SingleResponsibility;

Console.WriteLine("Hello, World!");

Console.WriteLine("Single responsibility");
new Report(new ConsolePrinter()).Print();
new Report(new PaperPrinter()).Print();
Console.WriteLine();

Console.WriteLine("Open/closed");
new Person().Cook(new Cook());
new Person().Cook(new Burger());
Console.WriteLine();

Console.WriteLine("Liskov");
new Capacity(new Rectangle());
try
{
    new Capacity(new Square());
}
catch (Exception e)
{
    Console.WriteLine(e);
}
Console.WriteLine();

Console.WriteLine("Interface Segregation");
new TextMessenger
    {
        Text = "Какой-то текст"
    }
    .Send();
new VideoMessenger
    {
        Content = Encoding.Default.GetBytes("Какое-то видео")
    }
    .Send();
Console.WriteLine();

Console.ReadKey();

// Принцип инверсии зависимостей готорит нам о том, что мы должны классы таким образом, чтобы они зависели от адстракций, которые они используют,
// а не от конкретных деталей реализаций. Примером служит подход Dependency Injection