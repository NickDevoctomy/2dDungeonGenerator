using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DungeonGenerator2d.UnitTests
{
    public class BoardTileExtensionsTests
    {
        [Fact]
        public void GivenBoardTileArray_AndFlip_WhenToFormattedString_ThenCorrectlyFormattedStringReturned()
        {
            // Arrange
            var board = new BoardTile[3, 4];
            board[0, 0] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[0, 1] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[0, 2] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[0, 3] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[1, 0] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[1, 2] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[2, 0] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[2, 1] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[2, 2] = new BoardTile(BoardTileType.Empty, 0, 0);

            // Act
            var output = board.ToFormattedString(true);

            // Assert
            Assert.Equal(
                "[1][-][-]\r\n" +
                "[1][1][1]\r\n" +
                "[1][-][1]\r\n" +
                "[1][1][1]", output);
        }

        [Fact]
        public void GivenBoardTileArray_AndNoFlip_WhenToFormattedString_ThenCorrectlyFormattedStringReturned()
        {
            // Arrange
            var board = new BoardTile[3, 4];
            board[0, 0] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[0, 1] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[0, 2] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[0, 3] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[1, 0] = new BoardTile(BoardTileType.Door, 0, 0);
            board[1, 2] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[2, 0] = new BoardTile(BoardTileType.Empty, 0, 0);
            board[2, 1] = new BoardTile(BoardTileType.Door, 0, 0);
            board[2, 2] = new BoardTile(BoardTileType.Empty, 0, 0);

            // Act
            var output = board.ToFormattedString(false);

            // Assert
            Assert.Equal(
                "[1][2][1]\r\n" +
                "[1][-][2]\r\n" +
                "[1][1][1]\r\n" +
                "[1][-][-]", output);
        }
    }
}
