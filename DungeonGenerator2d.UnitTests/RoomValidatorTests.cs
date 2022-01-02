using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class RoomValidatorTests
    {
        [Fact]
        public void GivenNull_WhenValidate_ThenArgumentExceptionThrown()
        {
            // Arrange
            var sut = new RoomValidator();

            // Act & Assert
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                sut.Validate(null);
            });
        }

        [Theory]
        [InlineData("Data/RoomValidator/valid/1.txt", false)]
        [InlineData("Data/RoomValidator/valid/2.txt", true)]
        [InlineData("Data/RoomValidator/valid/3.txt", true)]
        [InlineData("Data/RoomValidator/valid/4.txt", false)]
        public async Task GivenValidRoom_WhenValidate_ThenCorrectValidityReturned(
            string path,
            bool valid)
        {
            // Arrange
            var input = await File.ReadAllLinesAsync($"{path}");
            var inputArray = TestHelpers.CreateArrayFromText(input);
            var sut = new RoomValidator();

            // Act
            var result = sut.Validate(inputArray);

            // Assert
            Assert.Equal(valid, result);
        }
    }
}
