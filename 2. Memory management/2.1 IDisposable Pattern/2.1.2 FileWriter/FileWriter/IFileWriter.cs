namespace Convestudo.Unmanaged
{
    public interface IFileWriter
    {
        /// <summary>
        /// Write string to the file
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="ObjectDisposedException">If file handle is invalid</exception>
        void Write(string str);

        /// <summary>
        /// Write line to the file
        /// </summary>
        /// <param name="str"></param>
        void WriteLine(string str);
    }
}