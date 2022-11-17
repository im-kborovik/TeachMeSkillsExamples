namespace Solid.InterfaceSegregation;

public class TextMessenger : IMessenger, ITextContent
{
    public string Subject { get; set; }

    public string From { get; set; }

    public string To { get; set; }

    public string Text { get; set; }

    public void Send()
    {
        Console.WriteLine($"Отправить текстовое сообщение: {Text}");
    }
}