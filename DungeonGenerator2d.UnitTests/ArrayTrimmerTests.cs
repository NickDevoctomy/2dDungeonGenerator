using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class ArrayTrimmerTests
    {
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
            var inputArray = CreateArray(input);
            var outputArray = CreateArray(output);
            var sut = new ArrayTrimmer<object>();

            // Act
            var trimmed = sut.Trim(inputArray);

            // Assert
            Assert.NotNull(outputArray);
            Assert.True(trimmed.GetLength(0) == outputArray?.GetLength(0));
            Assert.True(trimmed.GetLength(1) == outputArray?.GetLength(1));
        }

        private object[,]? CreateArray(string[]? lines)
        {
            if(lines == null)
            {
                return null;
            }

            int rows = lines.Length;
            int cols = lines[0].Length;
            var array = new object[cols, rows];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if(lines[y][x] == '1')
                    {
                        array[x, y] = new object();
                    }
                }
            }

            return array;
        }
    }
}