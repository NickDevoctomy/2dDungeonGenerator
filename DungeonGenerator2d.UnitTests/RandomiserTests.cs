using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class RandomiserTests
    {
        [Theory]
        [InlineData(0, 100)]
        [InlineData(-100, 100)]
        [InlineData(-100, -50)]
        public void GivenIntRange_AndNewSeed_WhenGetNext_ThenValueReturnedWithinRange(
            int min,
            int max)
        {
            // Arrange
            var intRange = new IntRange(min, max);
            var sut = new Randomiser(new RandomiserOptions
            {
                Seed = Environment.TickCount,
            });

            // Act
            var value = sut.GetNext(intRange);

            // Assert
            Assert.True(value > min && value < max);
        }

        [Theory]
        [InlineData(0, 100, 2424, new int[]{ 8, 6, 11})]
        public void GivenIntRange_AndKnownSeed_When3ConsecutiveGetNext_ThenExpectedValuesReturned(
            int min,
            int max,
            int seed,
            int[] expected)
        {
            // Arrange
            var intRange = new IntRange(min, max);
            var sut = new Randomiser(new RandomiserOptions
            {
                Seed = seed,
            });

            // Act
            var value1 = sut.GetNext(intRange);
            var value2 = sut.GetNext(intRange);
            var value3 = sut.GetNext(intRange);

            // Assert
            Assert.Equal(expected[0], value1);
            Assert.Equal(expected[1], value2);
            Assert.Equal(expected[2], value3);
        }
    }
}
