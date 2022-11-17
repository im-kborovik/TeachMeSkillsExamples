namespace Solid.Liskov;

public class Square : Rectangle
{
    private int _height;
    private int _width;
    
    public override int Height
    {
        get => _height;
        set
        {
            _height = value;
            _width = value;
        }
    }

    public override int Width
    {
        get => _width;
        set
        {
            _height = value;
            _width = value;
        }
    }
}