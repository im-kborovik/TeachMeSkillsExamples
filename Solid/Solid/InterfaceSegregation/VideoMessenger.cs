using System.Text;

namespace Solid.InterfaceSegregation;

public class VideoMessenger : IMessenger, IStreamContent
{
    public string Subject { get; set; }

    public string From { get; set; }

    public string To { get; set; }

    public byte[] Content { get; set; }

    public void Send()
    {
        Console.WriteLine($"Отправить видео сообщение: {Encoding.Default.GetString(Content)}");
    }

}