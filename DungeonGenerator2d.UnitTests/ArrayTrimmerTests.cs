using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class ArrayTrimmerTests
    {
        [Fact]
        public void GivenNull_WhenTrim_ThenArgumentExceptionThrown()
        {
            // Arrange
            var sut = new ArrayTrimmer<object>();

            // Act & Assert
            Assert.ThrowsAny<System.ArgumentException>(() =>
            {
                sut.Trim(null);
            });
        }

        [Theory]
        [InlineData("Data/ArrayTrimmer/1")]
        [InlineData("Data/ArrayTrimmer/2")]
        [InlineData("Data/ArrayTrimmer/3")]
        [InlineData("Data/ArrayTrimmer/4")]
        [InlineData("Data/ArrayTrimmer/5")]
        [InlineData("Data/ArrayTrimmer/6")]
        public async Task GivenArray_WhenTrim_ThenTrimmedArrayReturned(string path)
        {
            // Arrange
            var input = await File.ReadAllLinesAsync($"{path}/input.txt");
            var output = await File.ReadAllLinesAsync($"{path}/output.txt");
            var inputArray = TestHelpers.CreateArrayFromText(input);
            var outputArray = TestHelpers.CreateArrayFromText(output);
            var sut = new ArrayTrimmer<object>();

            // Act
            var trimmed = sut.Trim(inputArray);

            // Assert
            Assert.NotNull(outputArray);
            Assert.True(trimmed.GetLength(0) == outputArray?.GetLength(0));
            Assert.True(trimmed.GetLength(1) == outputArray?.GetLength(1));
        }
    }
}