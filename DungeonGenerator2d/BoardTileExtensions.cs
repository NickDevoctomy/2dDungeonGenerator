using System;

namespace DungeonGenerator2d
{
    public static class BoardTileExtensions
    {
        public static void OutputToConsole(this BoardTile[,] board)
        {
            for (int y = board.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    Console.Write(board[x, y] != null ? "[X]" : "[-]");
                }
                Console.Write("\r\n");
            }
        }
    }
}
