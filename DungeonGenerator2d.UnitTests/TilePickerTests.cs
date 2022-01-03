using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class TilePickerTests
    {
        [Theory]
        [InlineData(0, 0, Direction.North, null, null)]
        [InlineData(1, 0, Direction.North, 1, 0)]
        [InlineData(2, 0, Direction.North, 2, 1)]
        [InlineData(3, 0, Direction.North, null, null)]
        [InlineData(3, 0, Direction.East, 1, 0)]
        [InlineData(3, 1, Direction.East, 2, 1)]
        [InlineData(3, 2, Direction.East, 2, 2)]
        [InlineData(3, 3, Direction.East, null, null)]
        [InlineData(3, 3, Direction.South, null, null)]
        [InlineData(2, 3, Direction.South, 2, 2)]
        [InlineData(1, 3, Direction.South, 1, 2)]
        [InlineData(0, 3, Direction.South, null, null)]
        [InlineData(0, 0, Direction.West, 1, 0)]
        [InlineData(0, 1, Direction.West, 1, 1)]
        [InlineData(0, 2, Direction.West, 1, 2)]
        [InlineData(0, 3, Direction.West, null, null)]
        public void GivenRoom_AndPoint_AndDirection_WhenPickFirstPointWallFromPoint_ThenCorrectPointReturned(
            int x,
            int y,
            Direction direction,
            int? expectedX,
            int? expectedY)
        {
            // Arrange
            var roomLines = new List<string>
            {
                "-1--",
                "-11-",
                "-11-",
                "----"
            };
            var room = TestHelpers.CreateArrayFromText(roomLines.ToArray());
            if(room == null)
            {
                throw new System.InvalidOperationException("Failed to create room array");
            }

            var sut = new TilePicker();

            // Act
            var point = sut.PickFirstPointWallFromPoint(
                room,
                new Point(x, y),
                direction);

            // Assert
            if(expectedX == null && expectedY == null)
            {
                Assert.Null(point);
            }
            else
            {
                Assert.NotNull(point);
                Assert.Equal(expectedX, point.GetValueOrDefault().X);
                Assert.Equal(expectedY, point.GetValueOrDefault().Y);
            }
        }

        [Theory]
        [InlineData(Direction.North, "1,0;2,1")]
        [InlineData(Direction.East, "1,0;2,1;2,2")]
        [InlineData(Direction.South, "1,2;2,2")]
        [InlineData(Direction.West, "1,0;1,1;1,2")]
        public void GivenRoom_AndDirection_WhenPickWallPoints_ThenCorrectPointsReturned(
            Direction direction,
            string expectedPointsString)
        {
            // Arrange
            var roomLines = new List<string>
            {
                "-1--",
                "-11-",
                "-11-",
                "----"
            };
            var room = TestHelpers.CreateArrayFromText(roomLines.ToArray());
            if (room == null)
            {
                throw new System.InvalidOperationException("Failed to create room array");
            }

            var expectedPoints = expectedPointsString.ParsePoints(';');
            var sut = new TilePicker();

            // Act
            var points = sut.PickWallPoints(
                room,
                direction);

            // Assert
            Assert.True(expectedPoints.All(x => points.Contains(x)));
            Assert.True(points.All(x => expectedPoints.Contains(x)));
        }

        [Theory]
        [InlineData("0,0", 2, Direction.North, 0)]
        [InlineData("0,0", 2, Direction.South, 0)]
        [InlineData("0,0;1,0", 2, Direction.North, 1)]
        [InlineData("0,0;1,0", 2, Direction.South, 1)]
        [InlineData("0,0;1,0;2,0;3,0", 2, Direction.North, 3)]
        [InlineData("0,0;1,0;2,0;3,0", 2, Direction.South, 3)]
        [InlineData("0,0;2,0;3,0", 2, Direction.North, 1)]
        [InlineData("0,0;2,0;3,0", 2, Direction.South, 1)]
        [InlineData("0,0;2,0;3,0", 1, Direction.North, 3)]
        [InlineData("0,0;2,0;3,0", 1, Direction.South, 3)]
        [InlineData("0,0", 2, Direction.East, 0)]
        [InlineData("0,0", 2, Direction.West, 0)]
        [InlineData("0,0;0,1", 2, Direction.East, 1)]
        [InlineData("0,0;0,1", 2, Direction.West, 1)]
        [InlineData("0,0;0,1;0,2;0,3", 2, Direction.East, 3)]
        [InlineData("0,0;0,1;0,2;0,3", 2, Direction.West, 3)]
        [InlineData("0,0;0,2;0,3", 2, Direction.East, 1)]
        [InlineData("0,0;0,2;0,3", 2, Direction.West, 1)]
        [InlineData("0,0;0,2;0,3", 1, Direction.East, 3)]
        [InlineData("0,0;0,2;0,3", 1, Direction.West, 3)]
        public void GivenPoints_AndCount_AndDirection_WhenPickAdjacentPoints_ThenCorrectPointsReturned(
            string pointsString,
            int count,
            Direction direction,
            int expectedCount)
        {
            // Arrange
            var points = pointsString.ParsePoints(';');
            var sut = new TilePicker();

            // Act
            var result = sut.PickAdjacentPoints(
                points,
                count,
                direction);

            // Assert
            Assert.Equal(expectedCount, result.Count());
        }
    }
}
