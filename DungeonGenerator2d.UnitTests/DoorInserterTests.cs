using System.Collections.Generic;
using System.Drawing;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class DoorInserterTests
    {
        [Fact]
        public void GivenRoom_AndDoorPoints_AndDoorExists_WhenDoorExists_ThenTrueReturned()
        {
            // Arrange
            var options = new RandomiserOptions
            {
                Seed = 100
            };
            var randomiser = new Randomiser(options);
            var room = new BoardTile[3, 1];
            room[0, 0] = new BoardTile(BoardTileType.None, 0, 0);
            room[1, 0] = new BoardTile(BoardTileType.Door, 1, 0);
            room[2, 0] = new BoardTile(BoardTileType.None, 2, 0);
            var doorPoints = new List<Point>
            {
                new Point(0,0),
                new Point(1,0)
            };
            var sut = new DoorInserter(
                randomiser,
                new TilePicker());

            // Act
            var exists = sut.DoorExists(
                room,
                doorPoints);

            // Assert
            Assert.True(exists);
        }

        [Fact]
        public void GivenRoom_AndDoorPoints_AndDoorNotExists_WhenDoorExists_ThenTrueReturned()
        {
            // Arrange
            var options = new RandomiserOptions
            {
                Seed = 100
            };
            var randomiser = new Randomiser(options);
            var sut = new DoorInserter(
                randomiser,
                new TilePicker());
            var room = new BoardTile[3, 1];
            room[0, 0] = new BoardTile(BoardTileType.None, 0, 0);
            room[1, 0] = new BoardTile(BoardTileType.None, 1, 0);
            room[2, 0] = new BoardTile(BoardTileType.None, 2, 0);
            var doorPoints = new List<Point>
            {
                new Point(0,0),
                new Point(1,0)
            };

            // Act
            var exists = sut.DoorExists(
                room,
                doorPoints);

            // Assert
            Assert.False(exists);
        }

        [Theory]
        [InlineData(1, 1, Direction.North, true)]
        [InlineData(4, 1, Direction.North, true)]
        [InlineData(4, 1, Direction.East, true)]
        [InlineData(4, 4, Direction.East, true)]
        [InlineData(1, 5, Direction.East, false)]
        [InlineData(1, 6, Direction.South, true)]
        [InlineData(4, 6, Direction.South, true)]
        [InlineData(1, 1, Direction.West, true)]
        [InlineData(1, 4, Direction.West, true)]
        [InlineData(4, 5, Direction.West, false)]
        public void GivenRoom_AndDoorPoints_AndDirection_WhenIsNextToExistingDoor_ThenCorrectResultReturned(
            int x,
            int y,
            Direction direction,
            bool expectedResult)
        {
            // Arrange
            var options = new RandomiserOptions
            {
                Seed = 100
            };
            var randomiser = new Randomiser(options);
            var sut = new DoorInserter(
                randomiser,
                new TilePicker());

            var roomLines = new List<string>
            {
                "------",
                "-1221-",
                "-2112-",
                "-2112-",
                "-1111-",
                "-1111-",
                "-1221-",
                "------"
            };
            var room = TestHelpers.CreateArrayFromText(roomLines.ToArray());
            if (room == null)
            {
                throw new System.InvalidOperationException("Failed to create room array");
            }

            // Act
            var result = sut.IsNextToExistingDoor(
                room,
                new List<Point> { new Point(x,y) },
                direction);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
