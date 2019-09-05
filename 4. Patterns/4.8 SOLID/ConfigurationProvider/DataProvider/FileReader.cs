using System.Collections.Generic;
using System.IO;

namespace ConfigurationProvider.DataProvider
{
    public interface IFileReader
    {
        IEnumerable<string> Read(string path);
    }

    public class FileReader : IFileReader
    {
        public IEnumerable<string> Read(string path) => File.ReadLines(path);
    }
}
