using System;
using System.Collections.Generic;
using System.Linq;
using Codyssey.Utils.Search;
using Xunit;

namespace Codyssey.Utils.Tests
{
    /// <summary>
    /// Test Bisect
    /// </summary>
    public partial class BisectTest
    {
        [Fact]
        public void TestBisect()
        {
            var haystack = new int[] { 1, 4, 5, 6, 8, 12, 15, 20, 21, 23, 23, 26, 29, 30 };
            var needle = new int[] { 0, 1, 2, 5, 8, 10, 22, 23, 29, 30, 31 };
            var rightExpected = new int[] { 0, 1, 1, 3, 5, 5, 9, 11, 13, 14, 14 };
            var leftExpected = new int[] { 0, 0, 1, 2, 4, 5, 9, 9, 12, 13, 14 };

            // items provided to the Bisect object is sorted order
            // from there, it will find item left of 8

            var bisect = new Bisect<int>(haystack, Comparer<int>.Default);

            Assert.Equal(rightExpected, needle.Select(bisect.Right).ToArray());
            Assert.Equal(leftExpected, needle.Select(bisect.Left).ToArray());
        }

        [Fact]
        public void TestReverse()
        {
            var haystack = new int[] { 100, 100, 99, 98, 97 };
            var needle = new int[] { 100, 99, 98, 97 };

            var leftExpected = new int[] { 0, 2, 3, 4 };
            var rightExpected = new int[] { 2, 3, 4, 5};

            var reverseComparer = Comparer<int>.Create((x, y) => y - x);
            var bisect = new Bisect<int>(haystack, reverseComparer);
            Assert.Equal(rightExpected, needle.Select(bisect.Right).ToArray());
            Assert.Equal(leftExpected, needle.Select(bisect.Left).ToArray());
        }
    }
}
