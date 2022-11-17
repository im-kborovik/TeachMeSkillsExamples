namespace Solid.OpenClosed;

/// <summary>
/// Принцип open/closed говорит нам о том, что мы должны создавать классы таким образом, чтобы они были максимально расширяемыми,
/// чтобы изменение фукнциональности вело не к изменениюю существующего кода, а к его расширению
/// </summary>
public class Person
{
    // Пример нарушения принципа open/closed
    // public void Cook(Cook cooker)
    // {
    //     cooker.Make();
    // }
    
    // Пример правильной реализации 
    public void Cook(ICooker cooker)
    {
        cooker.Make();
    }
}