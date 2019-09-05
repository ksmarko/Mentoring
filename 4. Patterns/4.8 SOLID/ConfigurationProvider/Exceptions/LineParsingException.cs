using System;

namespace ConfigurationProvider.Exceptions
{
    public class LineParsingException : Exception
    {
        public LineParsingException(string message) : base(message)
        {

        }
    }
}
