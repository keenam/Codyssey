using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Codyssey.Extensions.Tests
{
    /// <summary>
    /// Tests <see cref="FileExtensions"/>
    /// </summary>
    public class FileExtensionsTest
    {
        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(4096, new int[] { 4096 })]
        [InlineData(4097, new int[] { 4096, 1 })]
        public void TestRead4KBBlocks(int size, int[] blockSizes)
        {
            var filePath = Path.GetTempFileName();
            File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(new string('a', size)));

            Assert.Equal(blockSizes, filePath.Read4KBBlocks().Select(block => block.Length));
        }
    }
}
