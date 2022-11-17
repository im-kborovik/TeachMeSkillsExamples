namespace Solid.Liskov;

public class Rectangle
{
    public virtual int Height { get; set; }

    public virtual int Width { get; set; }

    public int GetArea()
    {
        return Height * Width;
    }
}