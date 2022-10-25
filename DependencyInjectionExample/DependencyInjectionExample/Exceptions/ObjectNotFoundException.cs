using System;

namespace DependencyInjectionExample.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string objName) : base($"{objName} not found")
        {
        }
    }
}