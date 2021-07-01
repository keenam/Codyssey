using System;
using Xunit;

namespace Codyssey.Extensions.Tests
{
    /// <summary>
    /// Tests <see cref="MathE"/>
    /// </summary>
    public class MathETest
    {
        [Theory]
        [InlineData(1 / 3.0, 2, 0.33)]
        [InlineData(1 / 3.0, 9, 0.333_333_333)]
        [InlineData(2.145, 2, 2.14)]
        public void TestGetFixedPoint(double value, int fixedPoint, double expected)
        {
            Assert.Equal(expected, MathE.ToFixed(value, fixedPoint));
        }

        [Fact]
        public void TestGetFixedPointDecimalException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MathE.ToFixed(1.23, -1);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                MathE.ToFixed(1.23, 10);
            });
        }
    }
}
