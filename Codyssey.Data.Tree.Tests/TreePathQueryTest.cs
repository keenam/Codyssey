using System;
using System.Linq;
using Xunit;

namespace Codyssey.Data.Tree.Tests
{
    /// <summary>
    /// Tests <see cref="TreePathQuery{T}"/>
    /// </summary>
    public partial class TreePathQueryTest
    {
        [Fact]
        public void TestGetPathTo()
        {
            var targetTree = new Tree<string>("x");

            var tree = new Tree<string>("a")
            {
                new Tree<string>("1"),
                new Tree<string>("2")
                {
                    targetTree,
                    new Tree<string>("y")
                    {
                        targetTree
                    }
                }
            };

            var pathSearch = new TreePathQuery<string>(tree);

            var values = pathSearch.GetDfsPathTo("x");
            //Assert.Collection(
            //    values,
            //    result => Assert.Equal(new string[] { "a", "2", "x" }, result),
            //    result => Assert.Equal(new string[] { "a", "2", "y", "x" }, result)
            //);

            Assert.Collection(
                values.Take(1),
                result => Assert.Equal(new string[] { "a", "2", "x" }, result)
            );

        }
    }
}
