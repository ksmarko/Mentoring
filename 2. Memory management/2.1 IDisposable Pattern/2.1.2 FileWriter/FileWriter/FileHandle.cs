using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

namespace FileWriter
{
    class FileHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        /// Close handle
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// Initialize new instance of <see cref="FileHandle"
        /// </summary>
        /// <param name="handle"></param>
        public FileHandle(IntPtr handle) : base(true)
        {
            SetHandle(handle);
        }

        /// <summary>
        /// Close handle
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}
