namespace Solid.Liskov;

/// <summary>
/// Принцип подстановки Барбары Лисков говорит нам о том, что мы должны проектировать базовые классы таким образом, чтобы они были максимально независимы от наследников,
/// т.е. чтобы наследники никаким образом не могли послиять на результаты выполнения членов базового класса.
/// </summary>
public class Capacity
{
    public int Value { get; }

    public Capacity(Rectangle rectangle)
    {
        rectangle.Height = 5;
        rectangle.Width = 10;
        var square = rectangle.GetArea();
        if (square == 50)
        {
            Value = square;
        }
        else
        {
            throw new Exception("Incorrect square");
        }
    }
}