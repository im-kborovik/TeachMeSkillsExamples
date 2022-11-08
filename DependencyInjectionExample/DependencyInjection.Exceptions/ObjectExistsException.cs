namespace DependencyInjection.Exceptions;

public class ObjectExistsException : Exception
{
    public ObjectExistsException(string objName) : base($"{objName} exists")
    {
    }
}