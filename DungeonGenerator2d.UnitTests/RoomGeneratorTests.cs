using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class RoomGeneratorTests
    {
        [Fact]
        public void GivenOptions_WhenGenerate_ThenRoomGenerated()
        {
            // Arrange
            var options = new RoomGeneratorOptions
            {
                Width = new IntRange(3, 10),
                Height = new IntRange(6, 20),
                Parts = new IntRange(2, 5),
                PartWidth = new IntRange(3, 5),
                PartHeight = new IntRange(3, 5)
            };
            var sut = new RoomGenerator(
                new Randomiser(new RandomiserOptions { Seed = 100 }),
                new RoomValidator(),
                new ArrayTrimmer<BoardTile>());

            // Act
            var room = sut.Generate(options);

            // Assert
            Assert.True(room.GetLength(0) >= options.Width.Min && room.GetLength(0) <= options.Width.Max);
            Assert.True(room.GetLength(1) >= options.Height.Min && room.GetLength(1) <= options.Height.Max);
            var hasTiles = false;
            for(int x = 0; x < room.GetLength(0); x++)
            {
                for(int y = 0; y < room.GetLength(1); y++)
                {
                    if(room[x,y] != null)
                    {
                        hasTiles = true;
                        break;
                    }
                }

                if(hasTiles)
                {
                    break;
                }
            }

            // This is an extremely basic test that the room contains at least 1 set tile
            // it doesn't assure that it's working but will do for now until we have more
            // conclusive tests to bolster this with
            Assert.True(hasTiles);  
        }
    }
}
