using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codyssey.Extensions
{
    /// <summary>
    /// File utilities.
    /// </summary>
    public static class FileExtensions
    {
        /// <summary>
        /// Gets 4KB blocks of the file
        /// </summary>
        /// <param name="filePath">The file path to read file from</param>
        /// <returns>4KB or less data in sequence</returns>
        /// <remarks>
        /// The file is locked until it's completely read or read is stopped.
        /// </remarks>
        public static IEnumerable<byte[]> Read4KBBlocks(this string filePath)
        {
            const int bufferSize_4KB = 4 * 1024;
            using (var fileStream = File.OpenRead(filePath))
            {
                var buffer = new byte[bufferSize_4KB];

                while (true)
                {
                    var bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        break;
                    }

                    if (bytesRead == buffer.Length)
                    {
                        yield return buffer;
                    }
                    else
                    {
                        yield return buffer.Take(bytesRead).ToArray();
                    }
                }
            }
        }
    }
}
