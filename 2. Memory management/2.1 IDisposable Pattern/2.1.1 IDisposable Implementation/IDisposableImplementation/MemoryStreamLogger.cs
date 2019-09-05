using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger : IDisposable
    {
        private StreamWriter _streamWriter;

        public MemoryStreamLogger()
        {
            var memoryStream = new FileStream("log.txt", FileMode.Create);
            _streamWriter = new StreamWriter(memoryStream);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }

        public void Log(string message)
        {
            _streamWriter.WriteLine(message);
        }
    }
}