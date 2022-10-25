using System;

namespace DependencyInjectionExample.Exceptions
{
    public class ObjectExistsException : Exception
    {
        public ObjectExistsException(string objName) : base($"{objName} exists")
        {
        }
    }
}