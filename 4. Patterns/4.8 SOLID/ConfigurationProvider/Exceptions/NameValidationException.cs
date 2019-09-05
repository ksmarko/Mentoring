using System;

namespace ConfigurationProvider.Exceptions
{
    public class NameValidationException : Exception
    {
        public NameValidationException(string message) : base(message)
        {

        }
    }
}
