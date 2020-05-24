using System.Linq;
using Xunit;

namespace Codyssey.Extensions.Tests
{
    /// <summary>
    /// Tests <see cref="StringExtensions"/>
    /// </summary>
    public class StringExtensionsTest
    {
        [Fact]
        public void TestSplitByLength()
        {
            var split = new string('0', 3).SplitByLength(2);
            Assert.Equal(2, split.Count());
            Assert.True(split.First().SequenceEqual(new char[] { '0', '0' }));
            Assert.True(split.Skip(1).Take(1).First().SequenceEqual(new char[] { '0' }));
        }
    }
}
