using System;
using Xunit;

namespace Codyssey.Extensions.Tests
{
    /// <summary>
    /// Tests <see cref="WesternEaster"/>
    /// </summary>
    public class WesternEasterTest
    {
        [Theory]
        [InlineData(2018, 4, 1)]
        [InlineData(2019, 4, 21)]
        [InlineData(2020, 4, 12)]
        [InlineData(2024, 3, 31)]
        public void TestEasterSunday(int easterYear, int expectedMonth, int expectedDay)
        {
            var easterSunday = new WesternEaster(easterYear).EasterSunday;

            Assert.Equal(easterSunday.Year, easterYear);
            Assert.Equal(easterSunday.Month, expectedMonth);
            Assert.Equal(easterSunday.Day, expectedDay);
        }

        [Theory]
        [InlineData(2019, 4, 19)]
        public void TestGoodFriday(int easterYear, int expectedMonth, int expectedDay)
        {
            var goodFriday = new WesternEaster(easterYear).GoodFriday;

            Assert.Equal(goodFriday.Year, easterYear);
            Assert.Equal(goodFriday.Month, expectedMonth);
            Assert.Equal(goodFriday.Day, expectedDay);
        }

        [Theory]
        [InlineData(2019, 4, 22)]
        public void TestEasterMonday(int easterYear, int expectedMonth, int expectedDay)
        {
            var easterMonday = new WesternEaster(easterYear).EasterMonday;

            Assert.Equal(easterMonday.Year, easterYear);
            Assert.Equal(easterMonday.Month, expectedMonth);
            Assert.Equal(easterMonday.Day, expectedDay);
        }

        [Fact]
        public void TestGetEasterMinMaxYear()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new WesternEaster(1582);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                new WesternEaster(10000);
            });
        }
    }
}
