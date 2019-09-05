using System;

namespace ConfigurationProvider.Exceptions
{
    public class FileParsingException : Exception
    {
        public FileParsingException(string path, int index, Exception innerException)
            : base($"Unable to parse file {path} at {index}.", innerException)
        {

        }
    }
}
