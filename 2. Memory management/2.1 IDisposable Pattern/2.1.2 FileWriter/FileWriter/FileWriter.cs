using FileWriter;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Convestudo.Unmanaged
{
    public class FileWriter: IFileWriter, IDisposable
    {
        private readonly FileHandle _fileHandle;

        /// <summary>
        /// Creates file
        /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx"/>
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateFile(string lpFileName, DesiredAccess dwDesiredAccess, ShareMode dwShareMode, IntPtr lpSecurityAttributes, CreationDisposition dwCreationDisposition, FlagsAndAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

        /// <summary>
        /// Writes data into the file
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="aBuffer"></param>
        /// <param name="cbToWrite"></param>
        /// <param name="cbThatWereWritten"></param>
        /// <param name="pOverlapped"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteFile(FileHandle hFile, Byte[] aBuffer, UInt32 cbToWrite, ref UInt32 cbThatWereWritten, IntPtr pOverlapped);

        /// <summary>
        /// Initialize new instance of <see cref="FileWriter"/>
        /// </summary>
        /// <param name="fileName"></param>
        public FileWriter(string fileName)
        {
            var handle = CreateFile(
                fileName,
                DesiredAccess.Write,
                ShareMode.None, 
                IntPtr.Zero, 
                CreationDisposition.CreateAlways,
                FlagsAndAttributes.Normal,
                IntPtr.Zero);

            _fileHandle = new FileHandle(handle);

            if (_fileHandle.IsInvalid)
                ThrowLastWin32Err();
        }

        /// <summary>
        /// Writes string to the file
        /// </summary>
        /// <param name="str"></param>
        /// <exception cref="ObjectDisposedException">If file handle is invalid</exception>
        public void Write(string str)
        {
            if (_fileHandle.IsInvalid)
                throw new ObjectDisposedException(nameof(FileWriter));

            var bytes = Encoding.UTF8.GetBytes(str); 
            uint bytesWritten = 0;
            WriteFile(_fileHandle, bytes, (uint) bytes.Length, ref bytesWritten, IntPtr.Zero);
        }

        /// <summary>
        /// Writes line to the file
        /// </summary>
        /// <param name="str"></param>
        public void WriteLine(string str)
        {
            Write($"{str}{Environment.NewLine}");
        }

        private void ThrowLastWin32Err()
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_fileHandle != null && !_fileHandle.IsInvalid)
                {
                    _fileHandle.Close();
                }
            }
        }
    }
}