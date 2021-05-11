using System.Collections.Generic;
using System.Linq;
using Codyssey.Utils.Search;
using Xunit;

namespace Codyssey.Utils.Tests
{
    /// <summary>
    /// Tests binary tree data structure
    /// </summary>
    public class BTreeBuilderTest
    {
        [Fact]
        public void TestAdd()
        {
            var builder = new BTreeBuilder<int>(Comparer<int>.Default);

            var values = new int[] { 100, 50, 25, 0, 75, 150, 125, 175, 200 };

            builder.Add(values);

            var rootNode = builder.Build();

            Assert.Equal(values, new BTreeUtils().GetValuesInOrder(rootNode).ToArray());
        }
    }
}
