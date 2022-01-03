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
        [InlineData("Data/ArrayTrimmer/7")]
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

        [Fact]
        public void GivenSimpleArray_WhenTrimHorizontal_ThenArrayCorrectlyTrimmed()
        {
            // Arrange
            var array = new object[3, 3];
            array[1, 0] = new object();
            array[1, 1] = new object();
            array[1, 2] = new object();
            var sut = new ArrayTrimmer<object>();

            // Act
            var trimmed = sut.TrimHorizontal(array);

            // Assert
            Assert.Equal(1, trimmed.GetLength(0));
        }

        [Fact]
        public void GivenSimpleArray_WhenIsColEmpty_ThenCorrectValueReturned()
        {
            // Arrange
            var array = new object[3, 3];
            array[1, 0] = new object();
            array[1, 1] = new object();
            array[1, 2] = new object();
            var sut = new ArrayTrimmer<object>();

            // Act
            var col0 = sut.IsColEmpty(array, 0);
            var col1 = sut.IsColEmpty(array, 1);
            var col2 = sut.IsColEmpty(array, 2);

            // Assert
            Assert.True(col0);
            Assert.False(col1);
            Assert.True(col2);
        }

        [Fact]
        public void GivenSimpleArray_WhenTrimVertical_ThenArrayCorrectlyTrimmed()
        {
            // Arrange
            var array = new object[3, 3];
            array[0, 1] = new object();
            array[1, 1] = new object();
            array[2, 1] = new object();
            var sut = new ArrayTrimmer<object>();

            // Act
            var trimmed = sut.TrimVertical(array);

            // Assert
            Assert.Equal(1, trimmed.GetLength(1));
        }

        [Fact]
        public void GivenSimpleArray_WhenIsRowEmpty_ThenCorrectValueReturned()
        {
            // Arrange
            var array = new object[3, 3];
            array[0, 1] = new object();
            array[1, 1] = new object();
            array[2, 1] = new object();
            var sut = new ArrayTrimmer<object>();

            // Act
            var row0 = sut.IsRowEmpty(array, 0);
            var row1 = sut.IsRowEmpty(array, 1);
            var row2 = sut.IsRowEmpty(array, 2);

            // Assert
            Assert.True(row0);
            Assert.False(row1);
            Assert.True(row2);
        }
    }
}